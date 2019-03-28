using System;
namespace ECommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }
<<<<<<< HEAD
=======
        public string Name { get; set; }
>>>>>>> 695bd70e1f15506a969138939875be52a9bc9ca7
        public Cart Cart { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {
        }
    }
}
