using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int ProductTypeId { get; set; }

    public int MaterialId { get; set; }

    public int FinishTypeId { get; set; }

    public int SizeId { get; set; }

    public int ColorId { get; set; }

    public decimal Price { get; set; }

    public string DescriptionProduct { get; set; } = null!;

    public virtual Color Color { get; set; } = null!;

    public virtual ICollection<DetailQuote> DetailQuotes { get; set; } = new List<DetailQuote>();

    public virtual FinishType FinishType { get; set; } = null!;

    public virtual Material Material { get; set; } = null!;

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}
