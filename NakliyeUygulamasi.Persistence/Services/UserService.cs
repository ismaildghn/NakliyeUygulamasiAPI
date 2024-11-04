using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.User;
using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Domain.Entities.Identity;
using NakliyeUygulamasi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly NakliyeUygulamasiAPIDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly ITransporterWriteRepository _transporterWriteRepository;

        public UserService(UserManager<AppUser> userManager, ICustomerWriteRepository customerWriteRepository, ITransporterWriteRepository transporterWriteRepository, NakliyeUygulamasiAPIDbContext context)
        {
            _userManager = userManager;
            _customerWriteRepository = customerWriteRepository;
            _transporterWriteRepository = transporterWriteRepository;
            _context = context;
        }


        public async Task<CreateUserResponse> CreateTransporter(CreateTransporter model)
        {
            AppUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserType = Domain.Enums.UserType.Transporter,
            };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return new CreateUserResponse
                {
                    Succeeded = false,
                    Message = string.Join("\n", result.Errors.Select(e => $"{e.Code} - {e.Description}"))
                };
            }
            try
            {
                await _transporterWriteRepository.AddAsync(new()
                {
                    CompanyName = model.CompanyName,
                    Id = Guid.NewGuid(),
                    AppUserId = user.Id,
                    LicenseNumber = model.LicenseNumber,
                    CreatedDate = DateTime.UtcNow,
                });

                await _transporterWriteRepository.SaveAsync();


                return new CreateUserResponse
                {
                    Succeeded = true,
                    Message = "Kullanıcı başarıyla oluşturuldu."
                };
            }
            catch (Exception ex)
            {
                return new CreateUserResponse
                {
                    Succeeded = false,
                    Message = $"Nakliyeci kaydı sırasında bir hata oluştu: {ex.Message}"
                };
            }
        }

        public async Task<CreateUserResponse> CreateCustomer(CreateCustomer model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                AppUser user = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserType = Domain.Enums.UserType.Customer
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return new CreateUserResponse
                    {
                        Succeeded = false,
                        Message = string.Join("\n", result.Errors.Select(e => $"{e.Code} - {e.Description}"))
                    };
                }

                await _customerWriteRepository.AddAsync(new()
                {
                    Id = Guid.NewGuid(),
                    AppUserId = user.Id,
                    NameSurname = model.NameSurname,
                    PersonelIdNumber = model.PersonelIdNumber,
                    CreatedDate = DateTime.UtcNow,
                });

                await _customerWriteRepository.SaveAsync();

                await transaction.CommitAsync();

                return new CreateUserResponse
                {
                    Succeeded = true,
                    Message = "Kullanıcı başarıyla oluşturuldu."
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new CreateUserResponse
                {
                    Succeeded = false,
                    Message = $"Nakliyeci kaydı sırasında bir hata oluştu: {ex.Message}"
                };
            }
        }
        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {

            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new Exception("Kullanıcı Adı Veya Şifre Hatalı");
            }

        }
    }
}
