using System;
using Dapper;
using ECommerce.Models;
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

        public int Create(Customer customer)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO customer (Name, Address, ZipCode, City, Country) VALUES (@name, @address, @zipCode, @city, @country)", customer);
                return connection.QuerySingleOrDefault<int>("SELECT CustomerId FROM customer ORDER BY CustomerId DESC LIMIT 1");
            }
        }
    }
}