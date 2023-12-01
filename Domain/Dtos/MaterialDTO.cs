namespace swiftcarpenterApi.Domain.Dtos
{
    public class MaterialDTO
    {
        public int Id { get; set; }

        public string MaterialName { get; set; } = null!;

        public string? ImgMaterial { get; set; }
    }
}
