using E_Shelf_WebApi.Abstract;
using E_Shelf_WebApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Shelf_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(id);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var addedProduct = await _productRepository.CreateAsync(product);
            return Created(string.Empty, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            var checkIfProductExists = await _productRepository.GetByIdAsync(product.Id);
            if (checkIfProductExists == null)
            {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var checkIfProductExists = await _productRepository.GetByIdAsync(id);
            if (checkIfProductExists == null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }
    }
}
