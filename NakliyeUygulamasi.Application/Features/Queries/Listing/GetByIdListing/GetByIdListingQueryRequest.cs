using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetByIdListing
{
    public class GetByIdListingQueryRequest : IRequest<GetByIdListingQueryResponse>
    {
        public string ListingId { get; set; }
    }
}
