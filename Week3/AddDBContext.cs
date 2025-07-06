using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RetailInventorySystem.Data
{
    public class AddDBContext : DbContext
    {
        public AddDBContext(DbContextOptions<AddDBContext> options) : base(options) { }

        // Parameterless constructor for design-time tools
        public AddDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RetailStore;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Seed data (only used for migrations)
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Groceries" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 75000, CategoryId = 1 },
                new Product { Id = 2, Name = "Rice", Price = 1200, CategoryId = 2 }
            );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}