using NakliyeUygulamasi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Neighbourhood : BaseEntity
    {
        public string NeighbourhoodName { get; set; }
        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
