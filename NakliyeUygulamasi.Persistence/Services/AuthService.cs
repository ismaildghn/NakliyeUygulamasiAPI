using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.Abstractions.Token;
using NakliyeUygulamasi.Application.DTOs;
using NakliyeUygulamasi.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly ITokenHandler _tokenHandler;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;

        public AuthService(ITokenHandler tokenHandler, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<Token> LoginAsync(string username, string password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(username);
            
            if (user == null)
            {
                throw new Exception("Kullanıcı Adı Veya Şifre Hatalı");

            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                Token token = await _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new Exception("Kimlik Doğrulama Hatası");
            
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = await _tokenHandler.CreateAccessToken(15, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            throw new Exception("Kullanıcı Adı Veya Şifre Hatalı");
        }
    }
}
