using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class Quote
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime DateQuote { get; set; }

    public DateTime? SaleDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<DetailQuote> DetailQuotes { get; set; } = new List<DetailQuote>();
}
