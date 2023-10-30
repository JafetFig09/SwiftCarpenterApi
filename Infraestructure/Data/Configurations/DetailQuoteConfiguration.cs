using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwiftCarpenter.Domain.Entities;
using System.Reflection.Emit;

namespace swiftcarpenterApi.Infraestructure.Data.Configurations
{
    public class DetailQuoteConfiguration : IEntityTypeConfiguration<DetailQuote>
    {
        public void Configure(EntityTypeBuilder<DetailQuote> builder)
        {


            builder.ToTable("DetailQuotes");
                builder.HasKey(e => e.Id).HasName("PK__DetailQu__3213E83FD6F9E4B0");

                builder.Property(e => e.Id).HasColumnName("id");
                builder.Property(e => e.Amount).HasColumnName("amount");
                builder.Property(e => e.ProductId).HasColumnName("productId");
                builder.Property(e => e.QuoteId).HasColumnName("quoteId");
                builder.Property(e => e.Subtotal).HasColumnName("subtotal");


            builder.HasOne(d => d.Product).WithMany(p => p.DetailQuotes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__DetailQuo__produ__4D94879B");

                builder.HasOne(d => d.Quote).WithMany(p => p.DetailQuotes)
                    .HasForeignKey(d => d.QuoteId)
                    .HasConstraintName("FK__DetailQuo__quote__4CA06362");
            
        }
    }
}
