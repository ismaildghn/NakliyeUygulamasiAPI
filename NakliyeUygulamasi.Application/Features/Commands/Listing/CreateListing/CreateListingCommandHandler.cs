using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.Listing.CreateListing
{
    public class CreateListingCommandHandler : IRequestHandler<CreateListingCommandRequest, CreateListingCommandResponse>
    {
        readonly IListingService _ListingService;

        public CreateListingCommandHandler(IListingService ListingService)
        {
            _ListingService = ListingService;
        }

        public async Task<CreateListingCommandResponse> Handle(CreateListingCommandRequest request, CancellationToken cancellationToken)
        {
            await _ListingService.CreateListingAsync(new()
            {
                Header = request.Header,
                DeliveryAddresId = request.DeliveryAddresId,
                Description = request.Description,
                PickupAddressId = request.PickupAddressId,
                ShippingDate = request.ShippingDate,
            });
            return new();
        }
    }
}
