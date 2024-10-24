using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.DTOs.User
{
    public class CreateCustomer
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string PersonelIdNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
