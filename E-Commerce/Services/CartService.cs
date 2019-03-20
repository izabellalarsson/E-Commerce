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
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Cart> Get()
        {
            return this.cartRepository.Get();
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

        public bool Add(Cart cart)
        {
            if (cart == null)
            {
                return false;
            }

            this.cartRepository.Add(cart);

            return true;
        }

    }
}
