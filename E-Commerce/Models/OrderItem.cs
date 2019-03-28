using System;
namespace ECommerce.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }

        public OrderItem()
        {
        }
    }
}