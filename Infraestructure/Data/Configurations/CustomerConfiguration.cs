using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;
using System.Reflection.Emit;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
                builder.HasKey(e => e.Id).HasName("PK__Customer__3213E83F9BCE874C");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.CustomerName)
                    .HasMaxLength(255)
                    .HasColumnName("customerName");
                builder.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                builder.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("lastName");
                builder.Property(e => e.PasswordCustomer)
                    .HasMaxLength(255)
                    .HasColumnName("passwordCustomer");
            
        }
    }
}
