using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("Quotes");
            builder.HasKey(e => e.Id).HasName("PK__Quotes__3213E83F9F20DABB");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.CustomerId).HasColumnName("customerId");
            builder.Property(e => e.DateQuote)
                .HasColumnType("date")
                .HasColumnName("dateQuote");

            builder.HasOne(d => d.Customer).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Quotes__customer__49C3F6B7");
            builder.Property(e => e.SaleDate).HasColumnName("saleDate");
            builder.Property(e => e.StatusQuote).HasColumnName("statusQuote");

        }
    }
}
