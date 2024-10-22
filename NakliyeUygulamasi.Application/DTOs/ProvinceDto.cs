using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs
{
    public class ProvinceDto
    {
        public int Id { get; set; } // Burada Id'nin Guid olmasına dikkat edin.
        public string Name { get; set; }
        public List<DistrictDto> Districts { get; set; }
    }
}
