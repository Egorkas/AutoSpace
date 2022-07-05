using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces;
using Store.Domain;
using Store.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence
{
    public class StoreDbContext : DbContext, IStoreDbContext
    {
        public DbSet<Shop> Shops { get ; set; }
        public DbSet<Shop> Products { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ShopConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
