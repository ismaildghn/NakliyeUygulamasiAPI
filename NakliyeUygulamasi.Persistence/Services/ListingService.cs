using Microsoft.AspNetCore.Http;
using NakliyeUygulamasi.Application.Abstractions.Services;
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
        readonly IListingWriteRepository _ListingWriteRepository;
        readonly IListingReadRepository _ListingReadRepository;
        readonly IHttpContextAccessor _httpContextAccessor;

        public ListingService(IListingWriteRepository ListingWriteRepository, IListingReadRepository ListingReadRepository, IHttpContextAccessor httpContextAccessor)
        {
            _ListingWriteRepository = ListingWriteRepository;
            _ListingReadRepository = ListingReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateListingAsync(CreateListing createListing)
        {
            var customerId = _httpContextAccessor.HttpContext?.Items["CustomerId"]?.ToString();

            if (string.IsNullOrEmpty(customerId))
            {
                throw new UnauthorizedAccessException("User is not authorized.");
            }

            var Listing = await _ListingWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse(customerId),
                DeliveryAddressId = createListing.DeliveryAddresId,
                PickupAddressId = createListing.PickupAddressId,
                Description = createListing.Description,
                ShippingDate = createListing.ShippingDate,
                CreatedDate = DateTime.UtcNow
            });
            await _ListingWriteRepository.SaveAsync();
        }

        public async Task RemoveListingAsync(string ListingId)
        {
            Listing Listing = await _ListingReadRepository.GetByIdAsync(ListingId);
            if(Listing != null)
            {
                _ListingWriteRepository.Remove(Listing);
                await _ListingWriteRepository.SaveAsync();
            }

        }

        public async Task UpdateListingAsync(UpdateListing updateListing)
        {
          Listing Listing = await _ListingReadRepository.GetByIdAsync(updateListing.ListingId);
            
            if(Listing != null)
            {
                Listing.DeliveryAddressId = Guid.Parse(updateListing.DeliveryAddresId);
                Listing.PickupAddressId = Guid.Parse(updateListing.PickupAddressId);
                Listing.Description = updateListing.Description;
                Listing.ShippingDate = updateListing.ShippingDate;
                Listing.UpdatedDate = DateTime.UtcNow;
                _ListingWriteRepository.Update(Listing);
                await _ListingWriteRepository.SaveAsync();
            }
        }
    }
}
