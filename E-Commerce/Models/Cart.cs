using System;
namespace ECommerce.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CartTotalPrice { get; set; }
        public int UserId { get; set; }
        //public List<Product> Products { get; set; }

        public Cart()
        {
        }
    }
}
