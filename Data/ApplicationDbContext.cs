using E_Shelf_WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Shelf_WebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }    
    }
}
