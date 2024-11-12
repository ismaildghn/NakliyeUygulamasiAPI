using NakliyeUygulamasi.Application.DTOs.Listing;
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

    }
}
