using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetDistrictsForProvince
{
    public class GetDistrictsForProvinceQueryHandler : IRequestHandler<GetDistrictsForProvinceQueryRequest, GetDistrictsForProvinceQueryResponse>
    {
        private readonly IAddressService _addressService;

        public GetDistrictsForProvinceQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<GetDistrictsForProvinceQueryResponse> Handle(GetDistrictsForProvinceQueryRequest request, CancellationToken cancellationToken)
        {
            var districts = await _addressService.GetDistrictsForProvince(request.ProvinceId);
            return new GetDistrictsForProvinceQueryResponse
            {
                Districts = districts,
            };
        }
    }
}
