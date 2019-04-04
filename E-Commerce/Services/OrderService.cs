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

        public List <Order> Get()
        {
            var order = orderRepository.Get();

            return order;

        }

        public Order Get(int id)
        {
            var order = orderRepository.Get(id);
            order.Cart = cartRepository.Get(order.CartId);
            order.Customer = customerRepository.Get(order.CustomerId);

            return order;

        }

        public Order Create(Cart cart, Customer customer)
        {
            customer.CustomerId = customerRepository.Create(customer);

            var orderId = orderRepository.Create(cart, customer);
            var order = orderRepository.Get(orderId);

            order.Cart = cartRepository.Get(cart.CartId);
            order.Customer = customerRepository.Get(order.CustomerId);
            //order.TotalPrice = cart.Products.Sum(item => item.ProductPrice);
            //this.orderRepository.Delete(cart.CartId, order.CustomerId);
            return order;
        }

        //public void Delete(int cartId, int customerId)
        //{
        //}

    }
}
