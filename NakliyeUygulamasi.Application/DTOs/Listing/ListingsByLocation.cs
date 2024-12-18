using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs.Listing
{
    public class ListingsByLocation
    {
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? NeighbourhoodId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
