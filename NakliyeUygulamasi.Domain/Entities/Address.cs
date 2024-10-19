using NakliyeUygulamasi.Domain.Entities.Common;
using NakliyeUygulamasi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string ProvinceId { get; set; }
        public Province Province { get; set; }
        public string DistrictId { get; set; }
        public District District { get; set; }
        public string NeighbourhoodId { get; set; }
        public Neighbourhood Neighbourhood { get; set; }
        public string StreetAddress { get; set; }
        public AddressType AddressType { get; set; }
    }
}
