using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.Address.CreatePickupAddress
{
    public class CreatePickupAddressCommandHandler : IRequestHandler<CreatePickupAddressCommandRequest, CreatePickupAddressCommandResponse>
    {
        private readonly IAddressService _addressService;

        public CreatePickupAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<CreatePickupAddressCommandResponse> Handle(CreatePickupAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _addressService.CreatePickupAddressAsync(new()
            {
                CustomerId = request.CustomerId,
                ProvinceId = request.ProvinceId,
                DistrictId = request.DistrictId,
                NeighbourhoodId = request.NeighbourhoodId,
                StreetAddress = request.StreetAddress,
            });
            return new();
        }
    }
}
