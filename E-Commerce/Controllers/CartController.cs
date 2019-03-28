using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Web.Http.Cors;
//using System.Web.Http;


namespace ECommerce.Models
{
    //public class TestController : ApiController
    //{
    //    // Controller methods not shown...
    //}
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var cart = cartService.Get(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody]CartItem cartItem)
        {
            var cart = this.cartService.Add(cartItem.ProductId, cartItem.CartId, cartItem.Quantity);

            return Ok(cart);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Remove([FromBody]CartItem cartItem)
        {
            cartService.Delete(cartItem.ProductId, cartItem.CartId);
            return Ok();
        }

        ////ADD an update
        //public IActionResult Update(CartItem cartItem)
        //{
        //    cartService.Update(cartItem.ProductId, cartItem.CartId, cartItem.Quantity);
        //    return Ok();
        //}

    }
}
