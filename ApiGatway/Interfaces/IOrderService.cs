using Resouces.DTOs;

namespace ApiGatway.Interfaces
{
    public interface IOrderService
    {
        Task<bool> Order(List<ProductsDto> CartProducts, long UserId);
    }
}
