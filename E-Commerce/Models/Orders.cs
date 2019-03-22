using System;
namespace ECommerce.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int CostumerId { get; set; }
        public int TotalPrice { get; set; }
        public Cart Cart { get; set; }
        
         public Orders()
        {
        }
    }
}
