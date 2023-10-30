using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class Color
{
    public int Id { get; set; }

    public string ColorName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
