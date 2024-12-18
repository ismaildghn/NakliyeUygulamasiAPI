using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NakliyeUygulamasi.Application.Abstractions.Token;
using NakliyeUygulamasi.Domain.Entities.Identity;
using NakliyeUygulamasi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        readonly UserManager<AppUser> _userManager;

        public TokenHandler(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<Application.DTOs.Token> CreateAccessToken(int second, AppUser user)
        {

            var userWithDetails = await _userManager.Users
                .Include(u => u.Customer)
                .Include(u => u.Transporter)
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            Application.DTOs.Token token = new Application.DTOs.Token();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userWithDetails.Id),
               new(ClaimTypes.Name, userWithDetails.UserName),
               new("UserId", userWithDetails.Id)
            };

            if (userWithDetails.UserType == UserType.Customer && userWithDetails.Customer != null)
            {
                claims.Add(new Claim("CustomerId", userWithDetails.Customer.Id.ToString()));
            }
            else if (userWithDetails.UserType == UserType.Transporter && userWithDetails.Transporter != null)
            {
                claims.Add(new Claim("TransporterId", userWithDetails.Transporter.Id.ToString()));
            }

            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();
            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
