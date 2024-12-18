using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.AppUser.UserLogin
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        readonly IAuthService _authService;
public UserLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
           Token token = await _authService.LoginAsync(request.Username, request.Password, 90000);

            return new UserLoginCommandResponse
            {
                Token = token,
            };
        }
    }
}
