using NakliyeUygulamasi.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
        Task RemoveOrderAsync(string OrderId);
        Task UpdateOrderAsync(UpdateOrder updateOrder);

    }
}
