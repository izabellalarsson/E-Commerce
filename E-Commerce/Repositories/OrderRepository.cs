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
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Order> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var order = connection.Query<Order>("SELECT * FROM orders").ToList();
               
                return order;
            }
        }

        public Order Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var order = connection.QuerySingleOrDefault<Order>("SELECT * FROM orders WHERE OrderId = @id", new { id });

                return order;
            }
        }

        public int Create(Cart cart, Customer customer)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var customerId = customer.CustomerId;
                var cartId = cart.CartId;

                connection.Execute("INSERT INTO orders (CartId, CustomerId) VALUES (@cartId, @customerId)", new { cartId, customerId });
                var orderId = connection.QuerySingleOrDefault<int>("SELECT OrderId FROM orders ORDER BY OrderId DESC LIMIT 1");
                return orderId;
            }
        }

        //public void Delete(int cartId, int customerId)
        //{
        //    using (var connection = new MySqlConnection(this.connectionString))
        //    {
        //        connection.Execute("DELETE FROM cart WHERE CartId = @cartId AND CustomerId = @customerId", new { cartId, customerId });

        //    }
        //}

    }
}
