using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Products");
            builder.HasKey(e => e.Id).HasName("PK__Products__3213E83F5D19C139");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ColorId).HasColumnName("colorId");
            builder.Property(e => e.DescriptionProduct).HasColumnName("descriptionProduct");
            builder.Property(e => e.FinishTypeId).HasColumnName("finishTypeId");
            builder.Property(e => e.MaterialId).HasColumnName("materialId");
            builder.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            builder.Property(e => e.ProductTypeId).HasColumnName("productTypeId");
            builder.Property(e => e.SizeId).HasColumnName("sizeId");

            builder.HasOne(d => d.Color).WithMany(p => p.Products)
                .HasForeignKey(d => d.ColorId)
                .HasConstraintName("FK__Products__colorI__44FF419A");

            builder.HasOne(d => d.FinishType).WithMany(p => p.Products)
                .HasForeignKey(d => d.FinishTypeId)
                .HasConstraintName("FK__Products__finish__4316F928");

            builder.HasOne(d => d.Material).WithMany(p => p.Products)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__Products__materi__4222D4EF");

            builder.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .HasConstraintName("FK__Products__produc__412EB0B6");

            builder.HasOne(d => d.Size).WithMany(p => p.Products)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("FK__Products__sizeId__440B1D61");

        }
    }
}
