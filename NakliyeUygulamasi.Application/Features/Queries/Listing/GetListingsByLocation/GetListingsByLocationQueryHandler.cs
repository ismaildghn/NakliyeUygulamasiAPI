using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetListingsByLocation
{
    public class GetListingsByLocationQueryHandler : IRequestHandler<GetListingsByLocationQueryRequest, GetListingsByLocationQueryResponse>
    {
        private readonly IListingService _listingService;

        public GetListingsByLocationQueryHandler(IListingService listingService)
        {
            _listingService = listingService;
        }

        public async Task<GetListingsByLocationQueryResponse> Handle(GetListingsByLocationQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _listingService.GetListingsByLocationAsync(new DTOs.Listing.ListingsByLocation
            {
                DistrictId = request.DistrictId,
                NeighbourhoodId = request.NeighbourhoodId,
                ProvinceId = request.ProvinceId,
                Page = request.Page,
                Size = request.Size
            });

            return new GetListingsByLocationQueryResponse
            {
                Listings = data.Listings,
                TotalListingCount = data.TotalListingCount
            };
        }
    }
}
