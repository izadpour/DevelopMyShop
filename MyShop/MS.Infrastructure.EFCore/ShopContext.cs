using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastructure.EFCore.Mapping;
using ShopManagement.Domain.ProductCategoryAgg;

namespace Shop.Management.Infrastructure.EFCore
{
  public class ShopContext:DbContext
    {
        public DbSet<ProductCategory>  productCategories { get; set; }

        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
