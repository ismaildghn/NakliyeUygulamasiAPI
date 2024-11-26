using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetAllListings
{
    public class GetAllListingsQueryResponse
    {
        public int TotalListingCount { get; set; }
        public object Listings { get; set; }
    }
}
