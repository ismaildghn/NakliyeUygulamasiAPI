using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NakliyeUygulamasi.Application;
using NakliyeUygulamasi.Infrastructure;
using NakliyeUygulamasi.Persistence;
using System.Security.Claims;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddControllers();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true, // Olu�turulacak token de�erini kimlerin/hangi sitelerin kullanaca��n� belirledi�imiz de�er "www.mysite.com"
            ValidateIssuer = true, // Olu�turulacak token de�erini kimin da��tt���n� ifade etti�imiz de�erdir "www.myapi.com"
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true, // �retilecek olan token de�erinin uygulamam�za ait bir token oldu�unu ifade eden security key do�rulamas�

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            NameClaimType = ClaimTypes.Name
        };
    });



var app = builder.Build();


app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();