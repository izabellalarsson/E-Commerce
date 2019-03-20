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
    public class CartItemService
    {
        private readonly CartItemRepository cartItemRepository;

        public CartItemService(CartItemRepository cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }

        public List<CartItem> Get()
        {
            return this.cartItemRepository.Get();
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

        public bool Add(CartItem cartItem)
        {
            if (cartItem == null)
            {
                return false;
            }

            this.cartItemRepository.Add(cartItem);

            return true;
        }

    }
}
