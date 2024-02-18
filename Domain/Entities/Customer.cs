namespace SwiftCarpenter.Domain.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordCustomer { get; set; } = null!;

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
