using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class Size
{
    public int Id { get; set; }

    public string SizeName { get; set; } = null!;

    public string? High { get; set; }
    public string? Width { get; set; }
    public string? Lenght { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
