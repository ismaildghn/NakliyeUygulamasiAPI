using NakliyeUygulamasi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Neighbourhood 
    {
        public int NeighbourhoodId { get; set; }
        public string NeighbourhoodName { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
