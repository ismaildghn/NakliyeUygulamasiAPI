using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetAllListings
{
    public class GetAllListingsQueryHandler : IRequestHandler<GetAllListingsQueryRequest, GetAllListingsQueryResponse>
    {
        private readonly IListingService _listingService;

        public GetAllListingsQueryHandler(IListingService listingService)
        {
            _listingService = listingService;
        }

        public async Task<GetAllListingsQueryResponse> Handle(GetAllListingsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _listingService.GetAllListingsAsync(request.Page, request.Size);

            return new GetAllListingsQueryResponse
            {
                Listings = data.Listings,
                TotalListingCount = data.TotalListingCount
            };
        }
    }
}
