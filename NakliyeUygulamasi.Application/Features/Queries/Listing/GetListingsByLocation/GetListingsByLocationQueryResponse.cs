using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetListingsByLocation
{
    public class GetListingsByLocationQueryResponse
    {
        public int TotalListingCount { get; set; }
        public object Listings { get; set; }
    }
}
