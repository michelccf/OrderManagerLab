using Microsoft.AspNetCore.Mvc;
using OrderApi.Interfaces.Repositories;
using OrderApi.Interfaces.Services;
using Resouces.DTOs;

namespace OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Order(long UserId, List<ProductsDto> CartProducts)
        {
            return await _orderRepository.Order(UserId, CartProducts);
        }
    }
}
