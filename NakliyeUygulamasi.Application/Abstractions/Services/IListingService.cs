using Microsoft.AspNetCore.Mvc.RazorPages;
using NakliyeUygulamasi.Application.DTOs.Listing;
using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Abstractions.Services
{
    public interface IListingService
    {
        Task CreateListingAsync(CreateListing createListing);
        Task RemoveListingAsync(string ListingId);
        Task UpdateListingAsync(UpdateListing updateListing);
        Task<GetByIdListing> GetByIdListingAsync(string id);
        Task<GetListing> GetAllListingsAsync(int page, int size);
        Task<GetListing> GetListingsByLocationAsync(ListingsByLocation listingsByLocation);

    }
}
