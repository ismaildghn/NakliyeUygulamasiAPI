using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetProvinceList
{
    public class GetProvinceListQueryResponse
    {
        public List<Province> Provinces { get; set; }
    }
}
