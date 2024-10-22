using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Services
{
    public interface ITurkeyLocationService
    {
        Task<List<Province>> GetProvincesAsync();
        Task<List<District>> GetDistrictsAsync(int provinceId);
        Task<List<Neighbourhood>> GetNeighborhoodsAsync(int districtId);
    }
}
