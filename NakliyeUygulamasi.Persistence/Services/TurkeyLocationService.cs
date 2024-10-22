using NakliyeUygulamasi.Application.DTOs;
using NakliyeUygulamasi.Application.Services;
using NakliyeUygulamasi.Domain.Entities;
using NakliyeUygulamasi.Persistence.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Infrastructure.Services.TurkeyLocationService
{
    public class TurkeyLocationService : ITurkeyLocationService
    {
        private readonly HttpClient _httpClient;
        private readonly NakliyeUygulamasiAPIDbContext _dbContext; // DbContext'i ekle

        public TurkeyLocationService(HttpClient httpClient, NakliyeUygulamasiAPIDbContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task<List<Province>> GetProvincesAsync()
        {
            var provinces = await GetDataWithRetry<ProvinceDto, Province>(
                "https://turkiyeapi.dev/api/v1/provinces",
                async (data) =>
                {
                    var provincesList = data.Select(p => new Province
                    {
                        ProvinceId = p.Id,
                        ProvinceName = p.Name,
                    }).ToList();

                    // Provinces'ı veri tabanına kaydet
                    await _dbContext.Provinces.AddRangeAsync(provincesList); // Repository yerine DbContext kullanıldı
                    await _dbContext.SaveChangesAsync(); // Değişiklikleri kaydet

                    return provincesList;
                });

            return provinces;
        }

        public async Task<List<District>> GetDistrictsAsync(int provinceId) // provinceId int olarak değiştirildi
        {
            await Task.Delay(500); // Gecikme ekleme

            var districts = await GetDataWithRetry<DistrictDto, District>(
                "https://turkiyeapi.dev/api/v1/districts",
                async (data) =>
                {
                    var districtsList = data.Select(d => new District
                    {
                        DistrictId = d.Id, // int olarak al
                        DistrictName = d.Name,
                        ProvinceId = d.ProvinceId // int olarak kullan
                    }).ToList();

                    // Districts'ı veri tabanına kaydet
                    await _dbContext.Districts.AddRangeAsync(districtsList); // Repository yerine DbContext kullanıldı
                    await _dbContext.SaveChangesAsync(); // Değişiklikleri kaydet

                    return districtsList;
                });

            return districts;
        }

        public async Task<List<Neighbourhood>> GetNeighborhoodsAsync(int districtId)
        {
            var url = $"https://turkiyeapi.dev/api/v1/neighborhoods?districtId={districtId}";
            var neighborhoods = new List<Neighbourhood>();

            // Belirli bir sayıda deneme yapılacak
            int maxRetries = 5;
            int delayBetweenRetries = 5000; // 5 saniye bekleme süresi

            for (int retry = 0; retry < maxRetries; retry++)
            {
                try
                {
                    neighborhoods = await GetDataWithRetry<NeighbourhoodDto, Neighbourhood>(
                        url,
                        async (data) =>
                        {
                            var neighborhoodsList = data.Select(n => new Neighbourhood
                            {
                                NeighbourhoodId = n.Id, // int olarak al
                                NeighbourhoodName = n.Name,
                                DistrictId = n.DistrictId // districtId'yi kullan
                            }).ToList();

                            // Neighborhoods'ı veri tabanına kaydet
                            await _dbContext.Neighbourhoods.AddRangeAsync(neighborhoodsList); // Repository yerine DbContext kullanıldı
                            await _dbContext.SaveChangesAsync(); // Değişiklikleri kaydet

                            return neighborhoodsList;
                        });

                    return neighborhoods; // Başarılı bir şekilde aldığında, sonuçları döndür
                }
                catch (HttpRequestException ex) when (ex.Message.Contains("429"))
                {
                    // 429 hatası durumunda, bekle ve yeniden dene
                    if (retry < maxRetries - 1)
                    {
                        await Task.Delay(delayBetweenRetries);
                    }
                    else
                    {
                        // Son deneme sonrası hata fırlat
                        throw new Exception("Too many requests, please try again later.", ex);
                    }
                }
            }

            return neighborhoods; // Eğer tüm denemeler başarısız olursa, boş bir liste döndür
        }

        private async Task<List<TOutput>> GetDataWithRetry<TDto, TOutput>(
            string url,
            Func<List<TDto>, Task<List<TOutput>>> transformFunc)
        {
            int retryCount = 5; // Yeniden deneme sayısı
            int delay = 5000; // Bekleme süresi

            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    var response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<TDto>>>(content);

                    if (apiResponse?.Data == null)
                    {
                        throw new Exception("No data returned from API.");
                    }

                    return await transformFunc(apiResponse.Data);
                }
                catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    await Task.Delay(delay);
                    delay *= 2; // Bekleme süresini artırarak denemeye devam et
                }
                catch (JsonSerializationException ex)
                {
                    throw new Exception("Error deserializing JSON response: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred: " + ex.Message);
                }
            }

            throw new Exception("Too many requests, please try again later.");
        }
    }
}