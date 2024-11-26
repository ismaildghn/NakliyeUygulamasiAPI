using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs.Address
{
    public class AddressDto
    {
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string StreetAddress { get; set; }
    }
}
