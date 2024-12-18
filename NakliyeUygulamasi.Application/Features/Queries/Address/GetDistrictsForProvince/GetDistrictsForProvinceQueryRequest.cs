using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Queries.Address.GetDistrictsForProvince
{
    public class GetDistrictsForProvinceQueryRequest : IRequest<GetDistrictsForProvinceQueryResponse>
    {
        public string ProvinceId { get; set; }
    }
}
