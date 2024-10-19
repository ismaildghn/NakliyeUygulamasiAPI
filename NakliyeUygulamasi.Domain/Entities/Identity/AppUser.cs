using Microsoft.AspNetCore.Identity;
using NakliyeUygulamasi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public UserType UserType { get; set; }
        public Customer Customer { get; set; }
        public Transporter Transporter { get; set; }
    }
}
