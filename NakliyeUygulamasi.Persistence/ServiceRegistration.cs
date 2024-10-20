using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Application.Repositories.Address;
using NakliyeUygulamasi.Persistence.Context;
using NakliyeUygulamasi.Persistence.Repositories;
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

            services.AddScoped<IAddressReadRepository, AddressReadRepository>();
            services.AddScoped<IAddressWriteRepository, AddressWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IDistrictReadRepository, DistrictReadRepository>();
            services.AddScoped<IDistrictWriteRepository, DistrictWriteRepository>();
            services.AddScoped<INeighbourhoodReadRepository, NeighbourhoodReadRepository>();
            services.AddScoped<INeighbourhoodWriteRepository, NeighbourhoodWriteRepository>();
            services.AddScoped<IOfferReadRepository, OfferReadRepository>();
            services.AddScoped<IOfferWriteRepository, OfferWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProvinceReadRepository, ProvinceReadRepository>();
            services.AddScoped<IProvinceWriteRepository, ProvinceWriteRepository>();
            services.AddScoped<ITransporterReadRepository, TransporterReadRepository>();
            services.AddScoped<ITransporterWriteRepository, TransporterWriteRepository>();
        }
    }
}
