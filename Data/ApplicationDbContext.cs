using E_Shelf_WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace E_Shelf_WebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category Entity

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new() {Id = 1, Name = "Electronic"},
                new() {Id = 2, Name = "Clothing"}
            });

            // Product entity
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2");

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new() {Id = 1, Name = "Computer", CreatedDate = DateTime.Now.AddDays(-3),Price = 15000,Stock = 300, CategoryId = 1},
                new() {Id = 2, Name = "SmartPhone", CreatedDate = DateTime.Now.AddDays(-30),Price = 15000,Stock = 500, CategoryId = 1},
                new() {Id = 3, Name = "Mouse", CreatedDate = DateTime.Now.AddDays(-60),Price = 15,Stock = 1000, CategoryId = 1}
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }    
        public DbSet<Category> Categories{ get; set; }
    }
}
