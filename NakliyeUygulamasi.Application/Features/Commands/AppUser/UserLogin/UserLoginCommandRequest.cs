using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.AppUser.UserLogin
{
    public class UserLoginCommandRequest : IRequest<UserLoginCommandResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
