using Microsoft.Extensions.DependencyInjection;
using NakliyeUygulamasi.Application.Abstractions.Token;
using NakliyeUygulamasi.Infrastructure.Services.Token;

namespace NakliyeUygulamasi.Infrastructure
{
    public static class ServiceRegistration
    {

        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}