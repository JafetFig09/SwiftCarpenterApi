using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;
using System.Reflection.Emit;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {

            builder.ToTable("Sizes");
                builder.HasKey(e => e.Id).HasName("PK__Sizes__3213E83F7C645AA1");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.SizeName)
                    .HasMaxLength(255)
                    .HasColumnName("sizeName");
            builder.Property(e => e.High).HasColumnName("high");
            builder.Property(e => e.Width).HasColumnName("width");
            builder.Property(e => e.Lenght).HasColumnName("length");
          

        }
    }
}
