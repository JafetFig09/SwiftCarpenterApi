using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;
using System.Reflection.Emit;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class FinishTypeConfiguration : IEntityTypeConfiguration<FinishType>
    {
        public void Configure(EntityTypeBuilder<FinishType> builder) 
        {
            builder.ToTable("FinishTypes");
                builder.HasKey(e => e.Id).HasName("PK__FinishTy__3213E83F3B4AB7AD");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.FinishName)
                    .HasMaxLength(255)
                    .HasColumnName("finishName");
            

        }
    }
}
