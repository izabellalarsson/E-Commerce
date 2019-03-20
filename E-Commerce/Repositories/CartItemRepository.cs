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
    public class CartItemRepository
    {
        private readonly string connectionString;

        public CartItemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CartItem> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cartItem = connection.Query<CartItem>("SELECT * FROM cartItems").ToList();

                return cartItem;
            }
        }

        public void Add(CartItem cartItem)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            { 
            connection.Execute("INSERT INTO cartItems(CartId, ProductId, Quantity) VALUES(@cartProduct @quantity @cartId)", cartItem);

            }
        }
    }
}
