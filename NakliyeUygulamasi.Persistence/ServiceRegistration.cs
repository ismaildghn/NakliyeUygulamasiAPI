using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Application.Repositories.Address;
using NakliyeUygulamasi.Domain.Entities.Identity;
using NakliyeUygulamasi.Infrastructure.Services.TurkeyLocationService;
using NakliyeUygulamasi.Persistence.Context;
using NakliyeUygulamasi.Persistence.Repositories;
using NakliyeUygulamasi.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<NakliyeUygulamasiAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<NakliyeUygulamasiAPIDbContext>();

            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOfferReadRepository, OfferReadRepository>();
            services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ITransporterReadRepository, TransporterReadRepository>();
            services.AddScoped<ITransporterWriteRepository, TransporterWriteRepository>();


            services.AddScoped<ILocationManager, LocationManager>();
            services.AddScoped<ITurkeyLocationService, TurkeyLocationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}