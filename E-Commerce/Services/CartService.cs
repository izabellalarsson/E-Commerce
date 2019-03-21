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

        public Cart Get(int id)
        {
            return cartRepository.Get(id);
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

        public Cart Add(int productId, int cartId, int quantity)
        {
            //if (cart == null)
            //{
            //    return false;
            //}

            this.cartRepository.Add(productId, cartId, quantity);

            var cart = cartRepository.Get(cartId);

            return cart;
        }

        public void Delete(int productId, int cartId)
        {
            this.cartRepository.Delete(productId, cartId);
        }

    }
}
