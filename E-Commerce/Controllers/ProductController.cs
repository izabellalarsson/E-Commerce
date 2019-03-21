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
    public class ProductController : Controller
    {
        private readonly ProductService productService;

        public ProductController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.productService = new ProductService(new ProductRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return this.Ok(this.productService.Get());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Product product)
        {

            var result = this.productService.Add(product);


            if (!result)
            {
                return this.BadRequest("fail");
            }


            return Ok("success");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {

            var productItem = this.productService.Get(id);

            if (productItem == null)
            {
                return this.NotFound();
            }
            return this.Ok(this.productService.Get(id));
        }


    }
}
