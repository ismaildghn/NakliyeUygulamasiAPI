using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetNeighbourhoodForDistrict
{
    public class GetNeighbourhoodForDistrictQueryRequest : IRequest<GetNeighbourhoodForDistrictQueryResponse>
    {
        public string DistrictId { get; set; }
    }
}
