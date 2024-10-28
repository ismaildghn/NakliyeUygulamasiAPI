using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetProvinceList
{
    public class GetProvinceListQueryHandler : IRequestHandler<GetProvinceListQueryRequest, GetProvinceListQueryResponse>
    {
        private readonly IAddressService _addressService;

        public GetProvinceListQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<GetProvinceListQueryResponse> Handle(GetProvinceListQueryRequest request, CancellationToken cancellationToken)
        {
            var provinces = await _addressService.GetProvinceList();
            return new GetProvinceListQueryResponse
            {
                Provinces = provinces
            };
        }
    }
}
