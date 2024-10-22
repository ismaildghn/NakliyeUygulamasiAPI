using NakliyeUygulamasi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
        public ICollection<Neighbourhood> Neighbourhoods { get; set; }
    }
}
