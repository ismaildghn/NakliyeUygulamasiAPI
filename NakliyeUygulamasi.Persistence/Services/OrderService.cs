using Microsoft.AspNetCore.Http;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.Order;
using NakliyeUygulamasi.Application.Repositories;
using NakliyeUygulamasi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakliyeUygulamasi.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IHttpContextAccessor _httpContextAccessor;

        public OrderService(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, IHttpContextAccessor httpContextAccessor)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateOrderAsync(CreateOrder createOrder)
        {
            var customerId = _httpContextAccessor.HttpContext?.Items["CustomerId"]?.ToString();

            if (string.IsNullOrEmpty(customerId))
            {
                throw new UnauthorizedAccessException("User is not authorized.");
            }

            var order = await _orderWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Parse(customerId),
                DeliveryAddressId = createOrder.DeliveryAddresId,
                PickupAddressId = createOrder.PickupAddressId,
                Description = createOrder.Description,
                ShippingDate = createOrder.ShippingDate,
                CreatedDate = DateTime.UtcNow
            });
            await _orderWriteRepository.SaveAsync();
        }

        public async Task RemoveOrderAsync(string OrderId)
        {
            Order order = await _orderReadRepository.GetByIdAsync(OrderId);
            if(order != null)
            {
                _orderWriteRepository.Remove(order);
                await _orderWriteRepository.SaveAsync();
            }

        }

        public async Task UpdateOrderAsync(UpdateOrder updateOrder)
        {
          Order order = await _orderReadRepository.GetByIdAsync(updateOrder.OrderId);
            
            if(order != null)
            {
                order.DeliveryAddressId = Guid.Parse(updateOrder.DeliveryAddresId);
                order.PickupAddressId = Guid.Parse(updateOrder.PickupAddressId);
                order.Description = updateOrder.Description;
                order.ShippingDate = updateOrder.ShippingDate;
                order.UpdatedDate = DateTime.UtcNow;
                _orderWriteRepository.Update(order);
                await _orderWriteRepository.SaveAsync();
            }
        }
    }
}
