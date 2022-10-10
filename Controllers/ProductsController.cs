using Microsoft.AspNetCore.Mvc;

namespace E_Shelf_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[] { new {Name = "Computer" , Price = 13000 }, new { Name = "Phone", Price = 12000 } });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct()
        {
            return Ok(new[] { new { Name = "Computer", Price = 12000 }});
        }
    }
}
