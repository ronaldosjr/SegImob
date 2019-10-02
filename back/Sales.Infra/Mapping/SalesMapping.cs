using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;

namespace Sales.Infra.Mapping
{
    public class SalesMapping : BaseEntityMapping<Sale>
    {
        public override void Configure(EntityTypeBuilder<Sale> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Sales).ToLower());
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Seller).WithMany(p => p.Sales).HasForeignKey(p => p.SellerId);
            builder.Property(p => p.Total).IsRequired(true);

        }
    }
}
