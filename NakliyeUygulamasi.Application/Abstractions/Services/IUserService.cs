using NakliyeUygulamasi.Application.DTOs.User;
using NakliyeUygulamasi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<CreateUserResponse> CreateTransporter(CreateTransporter model);
        Task<CreateUserResponse> CreateCustomer(CreateCustomer model);
        Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate);
    }
}
