using E_Shelf_WebApi.Abstract;
using E_Shelf_WebApi.Data;
using E_Shelf_WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Shelf_WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(x=>x.Id == id);
        }
    }
}
