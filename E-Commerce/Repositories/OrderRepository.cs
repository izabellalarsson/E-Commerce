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
                var orders = connection.Query<Order>("SELECT * FROM orders").ToList();

                return orders;
            }
        }

        public Order Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var orderId = connection.QuerySingleOrDefault<Order>("SELECT * FROM orders WHERE OrderId = @id", new { id });

                return orderId;
            }
        }

        public int Create(Cart cart, Customer customer)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var totalPrice = 0;

                connection.Execute("INSERT INTO customer (Name, Address, ZipCode, City, Country) VALUES (@name, @address, @zipCode, @city, @country)", customer);
                var customerId = connection.QuerySingleOrDefault<int>("SELECT CustomerId FROM customer ORDER BY CustomerId DESC LIMIT 1");
                var cartId = cart.CartId;

                connection.Execute("INSERT INTO orders (CartId, CustomerId, TotalPrice) VALUES (@cartId, @customerId, @totalPrice)",
                new { cartId, customerId, totalPrice });
                var orderId = connection.QuerySingleOrDefault<int>("SELECT orderId FROM orders ORDER BY orderId DESC LIMIT 1");
                return orderId;

            }
        }

    }
}
