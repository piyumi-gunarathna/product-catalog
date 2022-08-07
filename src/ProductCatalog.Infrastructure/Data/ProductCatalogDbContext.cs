using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using ProductCatalog.Infrastructure.Data.EntityConfiguration;

namespace ProductCatalog.Infrastructure.Data
{
    public class ProductCatalogDbContext: DbContext
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options)
        {
        }

        internal DbSet<Category> Category { get; set; }
        internal DbSet<ProductDbModel> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        }
    }
}
