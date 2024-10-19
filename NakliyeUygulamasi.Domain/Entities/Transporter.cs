using NakliyeUygulamasi.Domain.Entities.Common;
using NakliyeUygulamasi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Transporter : BaseEntity
    {
        public string CompanyName { get; set; }
        public string LicenseNumber { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
