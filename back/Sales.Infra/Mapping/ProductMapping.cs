using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infra.Mapping
{
    public class ProductMapping : BaseEntityMapping<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Product).ToLower());
            builder.Property(p => p.Name).HasMaxLength(Product.NAME_LENGTH).HasMaxLength(Product.NAME_LENGTH);
            builder.Property(p => p.Price).IsRequired(true);
        }
    }
}
