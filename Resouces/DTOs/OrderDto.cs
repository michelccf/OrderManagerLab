using Resouces.Enums;

namespace Resouces.DTOs
{
    public class OrderDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public OrderStatusEnum Status { get; set; }
    }
}
