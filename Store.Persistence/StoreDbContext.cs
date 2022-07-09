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

            //#region AddProducts
            //var product1 = new Product
            //{
            //    ProductId = Guid.Parse("9F2C9C64-0D26-4CA9-9BBB-ABB84119E1E1"),
            //    ProductName = "Cucumber",
            //    Description = "Vegetables"
            //};
            //builder.Entity<Product>().HasData(product1);
            //#endregion

            //#region Add Shops
            //builder.Entity<Shop>().HasData(new Shop
            //{
            //    ShopId = Guid.Parse("EDCCEF67-0877-499C-8859-C36466F83399"),
            //    ShopName = "Vitalur",
            //    ShopAddress = "Minsk",
            //    OpeningTime = new TimeOnly(9, 0),
            //    ClosingTime = new TimeOnly(14, 0),
            //    Products = {product1}
            //});

            //#endregion
            base.OnModelCreating(builder);
        }
    }
}
