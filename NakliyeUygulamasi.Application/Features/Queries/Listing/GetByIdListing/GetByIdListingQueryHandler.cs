using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Listing.GetByIdListing
{
    public class GetByIdListingQueryHandler : IRequestHandler<GetByIdListingQueryRequest, GetByIdListingQueryResponse>
    {
        private readonly IListingService _listingService;

        public GetByIdListingQueryHandler(IListingService listingService)
        {
            _listingService = listingService;
        }

        public async Task<GetByIdListingQueryResponse> Handle(GetByIdListingQueryRequest request, CancellationToken cancellationToken)
        {
             var data = await _listingService.GetByIdListingAsync(request.ListingId);

            return new GetByIdListingQueryResponse
            {
                DeliveryAddress = data.DeliveryAddress,
                Description = data.Description,
                Header = data.Header,
                ListingCreatedDate = data.ListingCreatedDate,
                PickUpAddress = data.PickUpAddress,
                ShippingDate = data.ShippingDate
            };
        }
    }
}
