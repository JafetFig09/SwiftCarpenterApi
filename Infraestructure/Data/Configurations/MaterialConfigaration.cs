using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;
using System.Reflection.Emit;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class MaterialConfigaration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Materials");
                builder.HasKey(e => e.Id).HasName("PK__Material__3213E83FB45143CA");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.MaterialName)
                    .HasMaxLength(255)
                    .HasColumnName("materialName");
          


        }
    }
}
