using Microsoft.EntityFrameworkCore;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.Address;
using NakliyeUygulamasi.Domain.Entities;
using NakliyeUygulamasi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Services
{
    public class AddressService : IAddressService
    {
        private readonly NakliyeUygulamasiAPIDbContext _context;

        public AddressService(NakliyeUygulamasiAPIDbContext context)
        {
            _context = context;
        }

        public async Task<List<Province>> GetProvinceList()
        {
            DbSet<Province> table = _context.Set<Province>();
            var provinces =  table.AsQueryable().ToListAsync();
            return await provinces;
        }

        public async Task<List<District>> GetDistrictsForProvince(string provinceId)
        {
            DbSet<District> table = _context.Set<District>();
            var district = await table.Where(d => d.ProvinceId.ToString() == provinceId).ToListAsync();
                return district;
                
        }

        public async Task<List<Neighbourhood>> GetNeighbourhoodForDistrict(string districtId)
        {
            DbSet<Neighbourhood> table = _context.Set<Neighbourhood>();
            var neighbourhood = await table.Where(n => n.DistrictId.ToString() == districtId).ToListAsync();
            return neighbourhood;
        }

        public async Task CreateDeliveryAddress(CreateAddress createAddress)
        {
            var address = new Address
            {
                CustomerId = createAddress.CustomerId,
                Id = Guid.NewGuid(),
                ProvinceId = createAddress.ProvinceId,
                DistrictId = createAddress.DistrictId,
                NeighbourhoodId = createAddress.NeighbourhoodId,
                StreetAddress = createAddress.StreetAddress,
                AddressType = Domain.Enums.AddressType.Delivery,
                CreatedDate = DateTime.UtcNow,
            };
            await _context.AddAsync(address);
            await _context.SaveChangesAsync();
            
        }

        public async Task CreatePickupAddress(CreateAddress createAddress)
        {
            var address = new Address
            {
                CustomerId = createAddress.CustomerId,
                Id = Guid.NewGuid(),
                ProvinceId = createAddress.ProvinceId,
                DistrictId = createAddress.DistrictId,
                NeighbourhoodId = createAddress.NeighbourhoodId,
                StreetAddress = createAddress.StreetAddress,
                AddressType = Domain.Enums.AddressType.Pickup,
                CreatedDate = DateTime.UtcNow,
            };
            await _context.AddAsync(address);
            await _context.SaveChangesAsync();

        }
    }
}
