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
    [EnableCors(origins: "http://e-commerce.test", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    public class CartItemController : Controller
    {
        private readonly CartItemService cartItemService;

        public CartItemController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartItemService = new CartItemService(new CartItemRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return this.Ok(this.cartItemService.Get());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]CartItem cartItem)
        {

            var result = this.cartItemService.Add(cartItem);


            if (!result)
            {
                return this.BadRequest("fail");
            }


            return Ok("success");
        }


    }
}
