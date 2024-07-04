using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { Name = "product1" });
            products.Add(new Product { Name = "product2" });

            return Ok(products);
        }
    }
    public class Product
    {
        public string Name { get; set; }
    }
}
