using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class Material
{
    public int Id { get; set; }

    public string MaterialName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
