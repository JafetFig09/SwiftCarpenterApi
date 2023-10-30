using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class ProductType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public string DescriptionSize { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
