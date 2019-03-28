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

        public Order Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var order = connection.QuerySingleOrDefault<Order>("SELECT * FROM order WHERE OrderId = @id", new { id });
                order.Customer = connection.Query<Product>("SELECT * FROM orderItems c INNER JOIN cart p ON c.productName = p.ProductName AND c.ProductPrice = p.ProductPrice WHERE c.Cartid = @id", new { id }).ToList();

                return order;
            }
        }

        public int Create(Customer customer, int cartId)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var totalPrice = 0;

                connection.Execute("INSERT INTO customer (Name, Address, ZipCode, City, Country) VALUES (@name, @address, @zipCode, @city, @country)", customer);
                var customerId = connection.QuerySingleOrDefault<int>("SELECT CustomerId FROM customer ORDER BY CustomerId DESC LIMIT 1");

                var productPrice = connection.QuerySingleOrDefault<int>("SELECT ProductPrice FROM products");

                connection.Execute("INSERT INTO orderItem (Quantity, ProductPrice, ProductName) VALUES (@quantity, @productprice, @productname)",
                new { cartId, customerId, totalPrice });
                var orderId = connection.QuerySingleOrDefault<int>("SELECT orderId FROM orders ORDER BY orderId DESC LIMIT 1");
                return orderId;

            }
        }

    }
}
