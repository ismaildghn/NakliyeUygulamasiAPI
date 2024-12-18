using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Services
{
    public class LocationManager : ILocationManager
    {
        readonly ITurkeyLocationService _locationService;
        readonly NakliyeUygulamasiAPIDbContext _dbContext;

        public LocationManager(ITurkeyLocationService locationService, NakliyeUygulamasiAPIDbContext dbcontext)
        {
            _locationService = locationService;
            _dbContext = dbcontext;
        }

        public async Task PopulateDatabaseAsync()
        {
            var provinces = await _locationService.GetProvincesAsync();
            foreach (var province in provinces)
            {
                var exists = await _dbContext.Provinces.AnyAsync(p => p.ProvinceId == province.ProvinceId);
                if (!exists)
                {
                    await _dbContext.Provinces.AddAsync(province);
                }
            }
            await _dbContext.SaveChangesAsync();

            foreach (var province in provinces)
            {
                var districts = await _locationService.GetDistrictsAsync(province.ProvinceId);

                foreach (var district in districts)
                {
                    var exists = await _dbContext.Districts.AnyAsync(d => d.DistrictId == district.DistrictId);
                    if (!exists)
                    {
                        await _dbContext.Districts.AddAsync(district);
                    }
                }
                await _dbContext.SaveChangesAsync();

                foreach (var district in districts)
                {
                    var neighborhoods = await _locationService.GetNeighborhoodsAsync(district.DistrictId);

                    foreach (var neighborhood in neighborhoods)
                    {
                        var exists = await _dbContext.Neighbourhoods.AnyAsync(n => n.NeighbourhoodId == neighborhood.NeighbourhoodId);
                        if (!exists)
                        {
                            await _dbContext.Neighbourhoods.AddAsync(neighborhood);
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}


