using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain;

namespace Store.Persistence.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.ProductId);
            builder.HasIndex(product => product.ProductId).IsUnique();
            builder.Property(product => product.ProductName).IsRequired().HasMaxLength(50);
        }
    }
}
