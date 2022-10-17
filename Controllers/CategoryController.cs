using E_Shelf_WebApi.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace E_Shelf_WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/products")]

        public async Task<IActionResult> GetWithProducts(int id)
        {
            var data = await _context.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);
        }
    }
}
