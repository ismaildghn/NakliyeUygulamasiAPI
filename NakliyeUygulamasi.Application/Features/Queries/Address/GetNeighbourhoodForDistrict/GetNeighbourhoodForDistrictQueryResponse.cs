using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetNeighbourhoodForDistrict
{
    public class GetNeighbourhoodForDistrictQueryResponse
    {
        public List<Neighbourhood> Neighbourhoods { get; set; }
    }
}
