using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.AppUser.CreateCustomer
{
    public class CreateCustomerCommandResponse 
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
