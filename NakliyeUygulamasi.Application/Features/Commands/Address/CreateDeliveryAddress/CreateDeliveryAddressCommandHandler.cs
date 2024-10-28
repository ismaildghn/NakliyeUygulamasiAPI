using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.Address.CreateDeliveryAddress
{
    public class CreateDeliveryAddressCommandHandler : IRequestHandler<CreateDeliveryAddressCommandRequest, CreateDeliveryAddressCommandResponse>
    {
        private readonly IAddressService _addressService;

        public CreateDeliveryAddressCommandHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<CreateDeliveryAddressCommandResponse> Handle(CreateDeliveryAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _addressService.CreateDeliveryAddress(new()
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
