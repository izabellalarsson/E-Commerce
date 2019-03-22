using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;

namespace ECommerce.Models
{
    public class OrdersRepository
    {
        private readonly string connectionString;

        public OrdersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //public Orders Get(Cart cart, Customer customer)
        //{
        //    using (var connection = new MySqlConnection(this.connectionString))
        //    {
        //        var order = connection.QuerySingleOrDefault<Orders>("SELECT * FROM orders WHERE orderId = @id", new { cart.CartId });
        //        order.Cart = connection.Query<Cart>("SELECT * FROM cart c INNER JOIN costumer co ON c.CustomerId = co.CustomerId WHERE c.CartId = @id", 
        //        new { cart.CartId });

        //        return order;
        //    }
        //}

        public void Create(Cart cart, Customer customer)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var totalprice = 0;
                connection.Execute("INSERT INTO orders(CustomerId, TotalPrice, CartId VALUES(@costumerId, @totalPrice, @cartId)", 
                new { customer.CustomerId, totalprice, cart.CartId });
                
            }
        }

    }
}
