using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain;

namespace Store.Persistence.EntityTypeConfigurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasKey(shop => shop.ShopId);
            builder.HasIndex(shop => shop.ShopId).IsUnique();
            builder.Property(shop => shop.ShopName).IsRequired().HasMaxLength(35);
            builder.Property(shop => shop.ShopAddress).IsRequired().HasMaxLength(100);
            builder.Property(shop => shop.OpeningTime).IsRequired();
            builder.Property(shop => shop.ClosingTime).IsRequired();
        }
    }
}
