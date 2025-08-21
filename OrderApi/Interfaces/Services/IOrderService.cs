using Resouces.DTOs;

namespace OrderApi.Interfaces.Services
{
    public interface IOrderService
    {
        Task<bool> Order(long UserId, List<ProductsDto> CartProducts);
    }
}
