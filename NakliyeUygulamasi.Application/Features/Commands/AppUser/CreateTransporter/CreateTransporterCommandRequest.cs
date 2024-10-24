using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.AppUser.CreateTransporter
{
    public class CreateTransporterCommandRequest: IRequest<CreateTransporterCommandResponse>
    {
        public string UserName { get; set; } //Şirket adı
        public string CompanyName { get; set; } // Şirket adı uzun hali örn. Şirket adı Anonim şirketi vb.
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
