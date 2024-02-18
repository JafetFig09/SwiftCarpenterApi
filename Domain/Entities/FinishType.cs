namespace SwiftCarpenter.Domain.Entities;

public partial class FinishType
{
    public int Id { get; set; }

    public string FinishName { get; set; } = null!;

    public string? ImgFinish { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
