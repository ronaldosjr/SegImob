using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infra.Mapping
{
    public class SalesItemMapping : BaseEntityMapping<SalesItem>
    {
        public override void Configure(EntityTypeBuilder<SalesItem> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(SalesItem).ToLower());
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Sales).WithMany(p => p.SalesItem).HasForeignKey(p => p.SalesId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(p => p.SalesItem).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Total).IsRequired(true);
            builder.Property(p => p.Amount).IsRequired(true);

        }
    }
}
