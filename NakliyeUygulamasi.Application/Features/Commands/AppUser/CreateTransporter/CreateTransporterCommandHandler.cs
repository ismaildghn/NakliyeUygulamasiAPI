using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.AppUser.CreateTransporter
{
    public class CreateTransporterCommandHandler : IRequestHandler<CreateTransporterCommandRequest, CreateTransporterCommandResponse>
    {
        private readonly IUserService _userService;
public CreateTransporterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateTransporterCommandResponse> Handle(CreateTransporterCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateTransporter(new()
            {
                CompanyName = request.CompanyName,
                Email = request.Email,
                LicenseNumber = request.LicenseNumber,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                PhoneNumber = request.PhoneNumber,
                UserName = request.UserName
            });
            return new()
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
