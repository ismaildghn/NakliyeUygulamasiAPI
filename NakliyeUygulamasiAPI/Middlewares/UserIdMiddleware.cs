using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Repositories;
using System.Security.Claims;

namespace NakliyeUygulamasiAPI.Middlewares
{
    public class UserIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserIdMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
        {
            _next = next;           
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var appUserId = context.User.FindFirst("UserId")?.Value
                            ?? context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!string.IsNullOrEmpty(appUserId))
            {
                // Yeni bir scope oluşturuyoruz
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var customerReadRepository = scope.ServiceProvider.GetRequiredService<ICustomerReadRepository>();

                    // AppUserId ile CustomerId'yi alıyoruz
                    var customerId = await customerReadRepository
                        .Table
                        .Where(c => c.AppUserId == appUserId)
                        .Select(c => c.Id)
                        .FirstOrDefaultAsync();

                    // customerId mevcutsa, doğrudan HttpContext.Items içine ekliyoruz
                    if (customerId != Guid.Empty) // Boş Guid değilse
                    {
                        context.Items["CustomerId"] = customerId;
                    }
                }
            }

            await _next(context);
        }
    }
}
