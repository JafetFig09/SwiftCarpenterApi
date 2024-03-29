﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductTypes");
            builder.HasKey(e => e.Id).HasName("PK__ProductT__3213E83F011DBED2");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.DescriptionSize).HasColumnName("descriptionSize");
            builder.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasColumnName("typeName");
            builder.Property(e => e.ImgProductTypes).HasMaxLength(255).HasColumnName("imgProductTypes");



        }
    }
}
