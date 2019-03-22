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
    public class CustomerRepository
    {
        private readonly string connectionString;

        public CustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Customer Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var customer = connection.QuerySingleOrDefault<Customer>("SELECT * FROM customer WHERE CustomerId = @id", new { id });

                return customer;

            }
        }
    }
}
