using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetDistrictsForProvince
{
    public class GetDistrictsForProvinceQueryResponse
    {
        public List<District> Districts { get; set; }
    }
}
