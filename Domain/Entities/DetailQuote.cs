using System;
using System.Collections.Generic;

namespace SwiftCarpenter.Domain.Entities;

public partial class DetailQuote
{
    public int Id { get; set; }

    public int QuoteId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }
    public decimal Subtotal { get; set; }
    public virtual Product Product { get; set; } = null!;

    public virtual Quote Quote { get; set; } = null!;
}
