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
        Task<List<Province>> GetProvinceList();
        Task<List<District>> GetDistrictsForProvince(string provinceId);
        Task<List<Neighbourhood>> GetNeighbourhoodForDistrict(string districtId);
        Task CreateDeliveryAddress(CreateAddress createAddress);
        Task CreatePickupAddress(CreateAddress createAddress);

    }
}
