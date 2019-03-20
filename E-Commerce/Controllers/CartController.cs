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
    public class CartController : Controller
    {
        private readonly CartService cartService;

        public CartController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return this.Ok(this.cartService.Get());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Cart cart)
        {

            var result = this.cartService.Add(cart);


            if (!result)
            {
                return this.BadRequest("fail");
            }


            return Ok("success");
        }


    }
}
