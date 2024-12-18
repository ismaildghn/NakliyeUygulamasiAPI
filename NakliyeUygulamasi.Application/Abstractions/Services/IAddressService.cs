using NakliyeUygulamasi.Application.DTOs.Address;
using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Abstractions.Services
{
    public interface IAddressService
    {
        Task<List<Province>> GetProvinceListAsync();
        Task<List<District>> GetDistrictsForProvinceAsync(string provinceId);
        Task<List<Neighbourhood>> GetNeighbourhoodForDistrictAsync(string districtId);
        Task CreateDeliveryAddressAsync(CreateAddress createAddress);
        Task CreatePickupAddressAsync(CreateAddress createAddress);

    }
}
