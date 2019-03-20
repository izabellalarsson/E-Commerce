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

        public List<Cart> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cart = connection.Query<Cart>("SELECT * FROM cart").ToList();

                return cart;
            }
        }

        public void Add(Cart cart)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cart(" +
                                    "CartTotalPrice) " +
                                    "VALUES(" +
                                   "@cartTotalPrice)", cart);
            }
        }
    }
}
