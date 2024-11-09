using Microsoft.AspNetCore.Http;
using NakliyeUygulamasi.Application.Abstractions.Services;
using NakliyeUygulamasi.Application.DTOs.Order;
using NakliyeUygulamasi.Application.Repositories;
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

        public Task RemoveOrderAsync(string OrderId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderAsync(UpdateOrder updateOrder)
        {
            throw new NotImplementedException();
        }
    }
}
