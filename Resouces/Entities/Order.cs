using Resouces.Enums;
namespace Resouces.Entities
{
    public class Order
    {
       public long Id { get; set; }
       public long UserId { get; set; }
       public OrderStatusEnum Status { get; set; }
    }
}
