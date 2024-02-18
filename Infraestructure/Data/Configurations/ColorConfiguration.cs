using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;
//using System.Reflection.Emit;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {

            builder.ToTable("Colors");
            builder.HasKey(e => e.Id).HasName("PK__Colors__3213E83FB1E43FAD");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ColorName)
                .HasMaxLength(255)
                .HasColumnName("colorName");
            builder.Property(e => e.HexadecimalCode).HasColumnName("hexadecimalCode");

        }
    }
}
