using OrderApi.Interfaces.Repositories;
using Resouces.DTOs;
using Resouces.Entities;
using Resouces.Enums;
using Resources.DbContextService;
using StackExchange.Redis;

namespace OrderApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextService _dbContextService;
        public OrderRepository(DbContextService dbContextService) 
        {
            _dbContextService = dbContextService;
        }

        public async Task<bool> Order(long UserId, List<ProductsDto> CartProducts) 
        {
            orderdata order = new orderdata();
            order.userid = UserId;
            order.status = OrderStatusEnum.Created;
            _dbContextService.orderdata.Add(order);
            int resultOrder = await _dbContextService.SaveChangesAsync();

            await CreateOrderItens(order.id, CartProducts);
            int resultItens = await _dbContextService.SaveChangesAsync();

            return resultOrder > 0 && resultItens > 0;
        }

        private async Task CreateOrderItens(long id, List<ProductsDto> cartProducts)
        {
            List<orderitem> ListOrderItens = new List<orderitem>();
            foreach (ProductsDto cartProduct in cartProducts)
            {
                orderitem x = new orderitem();
                x.orderid = id;
                x.productid = cartProduct.Id;
                ListOrderItens.Add(x);
            }

            await _dbContextService.orderitem.AddRangeAsync(ListOrderItens);
        }
    }
}
