using NakliyeUygulamasi.Domain.Entities.Common;
using NakliyeUygulamasi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string NameSurname { get; set; }
        public string PersonelIdNumber { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Listing> Listings { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
