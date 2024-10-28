using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetNeighbourhoodForDistrict
{
    public class GetNeighbourhoodForDistrictQueryHandler : IRequestHandler<GetNeighbourhoodForDistrictQueryRequest, GetNeighbourhoodForDistrictQueryResponse>
    {
        private readonly IAddressService _addressService;

        public GetNeighbourhoodForDistrictQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public async Task<GetNeighbourhoodForDistrictQueryResponse> Handle(GetNeighbourhoodForDistrictQueryRequest request, CancellationToken cancellationToken)
        {
            var neighbourhood = await _addressService.GetNeighbourhoodForDistrict(request.DistrictId);

            return new GetNeighbourhoodForDistrictQueryResponse
            {
                Neighbourhoods = neighbourhood,
            };
        }
    }
}
