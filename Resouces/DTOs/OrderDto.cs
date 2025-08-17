using Resouces.Enums;

namespace Resouces.DTOs
{
    public record OrderDto (long Id, long UserId, OrderStatusEnum Status);
}
