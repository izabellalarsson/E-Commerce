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
    public class OrderService
    {
        public OrderRepository orderRepository;
        public CartRepository cartRepository;
        public CustomerRepository customerRepository;

        public OrderService(OrderRepository orderRepository, CartRepository cartRepository, CustomerRepository customerRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
            this.customerRepository = customerRepository;
        }


        public Order Get(int id)
        {
            var order = orderRepository.Get(id);
            order.Cart = cartRepository.Get(cartI);
            order.Customer = customerRepository.Get(order.CustomerId);

            return order;

        }

        public Order Create(Customer customer, int cartId)
        {
            var orderId = orderRepository.Create(customer, cartId);
            var order = orderRepository.Get(orderId);
            order.Customer = customerRepository.Get(order.CustomerId);
            order.Cart = cartRepository.Get(cartId);
            return order;
        }
    }
}
