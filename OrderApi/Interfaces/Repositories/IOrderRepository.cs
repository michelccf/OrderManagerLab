using Resouces.DTOs;

namespace OrderApi.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> Order(long UserId, List<ProductsDto> CartProducts);
    }
}
