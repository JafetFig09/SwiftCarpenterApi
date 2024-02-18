namespace SwiftCarpenter.Domain.Entities;

public partial class Material
{
    public int Id { get; set; }

    public string MaterialName { get; set; } = null!;

    public string? ImgMaterial { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
