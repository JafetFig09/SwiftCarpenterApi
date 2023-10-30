using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SwiftCarpenter.Domain.Entities;
using swiftcarpenterApi.Infraestructure.Data.Configurations;

namespace SwiftCarpenter.Infraestructure.Data;

public partial class SwiftCarpenterDbContext : DbContext
{
    public SwiftCarpenterDbContext()
    {
    }

    public SwiftCarpenterDbContext(DbContextOptions<SwiftCarpenterDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DetailQuote> DetailQuotes { get; set; }

    public virtual DbSet<FinishType> FinishTypes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ColorConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new DetailQuoteConfiguration());
        modelBuilder.ApplyConfiguration(new FinishTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialConfigaration());
        modelBuilder.ApplyConfiguration(new ProductTypeConfiguration ());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new QuoteConfiguration());
        modelBuilder.ApplyConfiguration(new  SizeConfiguration());  



            OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
