using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.Address;
using NakliyeUygulamasi.Application.DTOs.Listing;
using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Services
{
    public class ListingService : IListingService
    {
        readonly IListingWriteRepository _listingWriteRepository;
        readonly IListingReadRepository _listingReadRepository;
        readonly IHttpContextAccessor _httpContextAccessor;

        public ListingService(IListingWriteRepository listingWriteRepository, IListingReadRepository listingReadRepository, IHttpContextAccessor httpContextAccessor)
        {
            _listingWriteRepository = listingWriteRepository;
            _listingReadRepository = listingReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateListingAsync(CreateListing createListing)
        {
            var customerId = _httpContextAccessor.HttpContext?.Items["CustomerId"]?.ToString();

            if (string.IsNullOrEmpty(customerId))
            {
                throw new UnauthorizedAccessException("User is not authorized.");
            }

            var Listing = await _listingWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                Header = createListing.Header,
                CustomerId = Guid.Parse(customerId),
                DeliveryAddressId = createListing.DeliveryAddresId,
                PickupAddressId = createListing.PickupAddressId,
                Description = createListing.Description,
                ShippingDate = createListing.ShippingDate,
                CreatedDate = DateTime.UtcNow
            });
            await _listingWriteRepository.SaveAsync();
        }

        public async Task RemoveListingAsync(string ListingId)
        {
            Listing Listing = await _listingReadRepository.GetByIdAsync(ListingId);
            if(Listing != null)
            {
                _listingWriteRepository.Remove(Listing);
                await _listingWriteRepository.SaveAsync();
            }

        }

        public async Task UpdateListingAsync(UpdateListing updateListing)
        {
          Listing Listing = await _listingReadRepository.GetByIdAsync(updateListing.ListingId);
            
            if(Listing != null)
            {
                Listing.DeliveryAddressId = Guid.Parse(updateListing.DeliveryAddresId);
                Listing.PickupAddressId = Guid.Parse(updateListing.PickupAddressId);
                Listing.Description = updateListing.Description;
                Listing.ShippingDate = updateListing.ShippingDate;
                Listing.UpdatedDate = DateTime.UtcNow;
                _listingWriteRepository.Update(Listing);
                await _listingWriteRepository.SaveAsync();
            }
        }

        public async Task<GetListing> GetAllListingsAsync(int page, int size)
        {

            var query = _listingReadRepository.Table
                .Include(l => l.DeliveryAddress)
                .ThenInclude(da => da.Province)
                .Include(l => l.PickupAddress)
                .ThenInclude(pa => pa.Province);
                

            var data = query.Skip(page * size).Take(size);

            return new GetListing
            {
                TotalListingCount = await query.CountAsync(),
                Listings = await data.Select(l => new
                {
                    Header = l.Header,
                    ListingCreatedDate = l.CreatedDate,
                    ShippingDate = l.ShippingDate,
                    DeliveryProvince = l.DeliveryAddress.Province.ProvinceName,
                    PickUpProvince = l.PickupAddress.Province.ProvinceName

                }).ToListAsync()
            };
        }

        public async Task<GetByIdListing> GetByIdListingAsync(string id)
        {

            var query = await _listingReadRepository.Table
                 .Include(l => l.DeliveryAddress)
                 .ThenInclude(da => da.Province)
                 .ThenInclude(da => da.Districts)
                 .ThenInclude(da => da.Neighbourhoods)
                 .Include(l => l.PickupAddress)
                 .ThenInclude(pa => pa.Province)
                 .ThenInclude(pa => pa.Districts)
                 .ThenInclude(pa => pa.Neighbourhoods)
                 .Where(l => l.Id == Guid.Parse(id))
                 .SingleOrDefaultAsync();
                 
                 
            if (query == null)
            {
                throw new Exception("Listing not found.");
            }

            return new GetByIdListing
            {
                Header = query.Header,
                Description = query.Description,
                ListingCreatedDate = query.CreatedDate,
                ShippingDate = query.ShippingDate,
                DeliveryAddress = new AddressDto
                {
                    Province = query.DeliveryAddress.Province.ProvinceName,
                    District = query.DeliveryAddress.District.DistrictName,
                    Neighbourhood = query.DeliveryAddress.Neighbourhood.NeighbourhoodName,
                    StreetAddress = query.DeliveryAddress.StreetAddress
                },
                PickUpAddress = new AddressDto
                {
                    Province = query.PickupAddress.Province.ProvinceName,
                    District = query.PickupAddress.District.DistrictName,
                    Neighbourhood = query.PickupAddress.Neighbourhood.NeighbourhoodName,
                    StreetAddress = query.PickupAddress.StreetAddress
                }
                
            };
        }

        public async Task<GetListing> GetListingsByLocationAsync(ListingsByLocation listingsByLocation)
        {
            var query = _listingReadRepository.Table
                .Include(l => l.PickupAddress)
                .ThenInclude(pa => pa.Province)
                .ThenInclude(pa => pa.Districts)
                .ThenInclude(pa => pa.Neighbourhoods)
                .Where(l =>
                    (listingsByLocation.ProvinceId == null || l.PickupAddress.ProvinceId == listingsByLocation.ProvinceId) &&
                    (listingsByLocation.DistrictId == null || l.PickupAddress.DistrictId == listingsByLocation.DistrictId) &&
                    (listingsByLocation.NeighbourhoodId == null || l.PickupAddress.NeighbourhoodId == listingsByLocation.NeighbourhoodId)
                );

            var totalListingCount = await query.CountAsync();

            var data = query.Skip(listingsByLocation.Page * listingsByLocation.Size).Take(listingsByLocation.Size);

            return new GetListing
            {
                TotalListingCount = totalListingCount,
                Listings = await data.Select(l => new
                {
                    Header = l.Header,
                    ListingCreatedDate = l.CreatedDate,
                    ShippingDate = l.ShippingDate,
                    DeliveryProvince = l.DeliveryAddress.Province.ProvinceName,
                    PickUpProvince = l.PickupAddress.Province.ProvinceName
                }).ToListAsync()
            };


            
                
               
                

            
        }
    }
}
