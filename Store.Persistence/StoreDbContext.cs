using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain;
using Store.Persistence.EntityTypeConfigurations;

namespace Store.Persistence
{
    public class StoreDbContext : DbContext, IStoreDbContext
    {
        public DbSet<Shop> Shops { get ; set; }
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShopConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());

            #region AddProducts
            var product1 = new Product
            {
                ProductId = Guid.Parse("743A64EF-BCCB-4E6D-8543-4A65BC0FE846"),
                ProductName = "Tomato",
                Description = "Vegetables"
            };
            var product2 = new Product
            {
                ProductId = Guid.Parse("09133C5E-9733-40F9-BED5-D485F27E448E"),
                ProductName = "Potato",
                Description = "Vegetables"
            };
            
            #endregion
            #region Add Shops
            var shop1 = new Shop
            {
                ShopId = Guid.Parse("18DD943B-73BE-47C9-8A89-E440ACCB4A1D"),
                ShopName = "Sosedi",
                ShopAddress = "Minsk",
                OpeningTime = new DateTime(2015, 7, 21, 9, 0, 0),
                ClosingTime = new DateTime(1, 1, 1, 14, 0, 0)
            };

            builder.Entity<Product>().HasData(product1);
            builder.Entity<Product>().HasData(product2);
            builder.Entity<Shop>().HasData(shop1);
            builder.Entity<Product>()
                .HasMany(p => p.Shops)
                .WithMany(t => t.Products)
                .UsingEntity<Dictionary<string, object>>(
                "ProductShop",
                r => r.HasOne<Shop>().WithMany().HasForeignKey("ShopId"),
                l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                je =>
                {
                    je.HasKey("ProductId", "ShopId");
                    je.HasData(
                        new { ProductId = Guid.Parse("743A64EF-BCCB-4E6D-8543-4A65BC0FE846"), ShopId = Guid.Parse("18DD943B-73BE-47C9-8A89-E440ACCB4A1D") },
                        new { ProductId = Guid.Parse("09133C5E-9733-40F9-BED5-D485F27E448E"), ShopId = Guid.Parse("18DD943B-73BE-47C9-8A89-E440ACCB4A1D") }
                        );
                });
            #endregion
            base.OnModelCreating(builder);
        }
    }
}
