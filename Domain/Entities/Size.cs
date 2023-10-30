using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class Size
{
    public int Id { get; set; }

    public string SizeName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
