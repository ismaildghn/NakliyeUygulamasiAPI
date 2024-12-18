using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetListingsByLocation
{
    public class GetListingsByLocationQueryRequest : IRequest<GetListingsByLocationQueryResponse>
    {
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? NeighbourhoodId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
