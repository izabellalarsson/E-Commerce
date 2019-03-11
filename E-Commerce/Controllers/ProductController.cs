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
    [EnableCors(origins: "http:/e-commerce.test", headers: "*", methods: "*")]
    //public class TestController : ApiController
    //{
    //    // Controller methods not shown...
    //}
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


    }
}
