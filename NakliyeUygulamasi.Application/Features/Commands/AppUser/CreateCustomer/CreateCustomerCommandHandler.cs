using MediatR;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Features.Commands.AppUser.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly IUserService _userService;

        public CreateCustomerCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse response = await _userService.CreateCustomer(new()
            {
                NameSurname = request.NameSurname,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                PersonelIdNumber = request.PersonelIdNumber,
                PhoneNumber = request.PhoneNumber,
            });

            return new CreateCustomerCommandResponse
            {
                Message = response.Message,
                Succeeded = response.Succeeded,
            };
        }
    }
}
