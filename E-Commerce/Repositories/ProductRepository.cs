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
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var products = connection.Query<Product>("SELECT * FROM products").ToList();

                return products;
            }
        }

        public void Add(Product product)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO products(" +
            	                    "ProductName, " +
            	                    "ProductDescription) " +
            	                    "VALUES(" +
            	                    "@productName, " +
                                   "@productDescription)", product);

               
            }
        }
    }
}
