﻿using System;
namespace ECommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }
        public string Name { get; set; }
        public Cart Cart { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {
        }
    }
}
