using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Dapper;
using MySql.Data.MySqlClient;
using System.Web.Http;


namespace ECommerce.Models
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> Get()
        {
            return this.productRepository.Get();
        }

        public Product Get(int id)
        {
            if (id < 1)
            {
                return null;
            }
            return this.productRepository.Get(id);
        }

        public static void Register(HttpConfiguration config)
        {
            // New code
            config.EnableCors();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }

        public bool Add(Product product)
        {
            if (product == null)
            {
                return false;
            }

            this.productRepository.Add(product);

            return true;
        }

    }
}
