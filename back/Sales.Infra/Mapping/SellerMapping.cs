using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infra.Mapping
{
    public class SellerMapping : BaseEntityMapping<Seller>
    {
        public override void Configure(EntityTypeBuilder<Seller> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Seller).ToLower());
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(Seller.NAME_LENGTH);
        }
    }
}
