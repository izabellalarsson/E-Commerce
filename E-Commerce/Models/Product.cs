using System;
namespace ECommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }

        public Product()
        {
        }
    }
}
