using Backend.Domain.Entities;
using Backend.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.DataContext
{
    public class ProductContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Products.db", b => b.MigrationsAssembly("Backend"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
