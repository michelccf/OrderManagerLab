using Resouces.Enums;
namespace Resouces.Entities
{
    public class orderdata
    {
       public long id { get; set; }
       public long userid { get; set; }
       public OrderStatusEnum status { get; set; }
    }
}
