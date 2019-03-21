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
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Cart Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cart = connection.QuerySingleOrDefault<Cart>("SELECT * FROM cart WHERE CartId = @id", new { id });
                cart.Products = connection.Query<Product>("SELECT * FROM cartItems c INNER JOIN products p ON c.ProductId = p.ProductId WHERE c.CartId = @id", new { id }).ToList();

                return cart;
            }
        }

        public void Add(int productId, int cartId, int quantity)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cartItems(CartId, ProductId, Quantity) VALUES(@cartId, @productId, @quantity)", new { cartId, productId, quantity });
            }
        }

        public void Delete(int productId, int cartId)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM cartItems WHERE ProductId = @productId AND CartId = @cartId", new { cartId, productId });
            }
        }
    }
}
