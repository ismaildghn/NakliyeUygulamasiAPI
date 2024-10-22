using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs
{
    public class DistrictDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public List<NeighbourhoodDto> Neighbourhoods { get; set; }
    }
}
