namespace swiftcarpenterApi.Domain.Dtos
{
    public class SizeResponseDTO
    {
        public int Id { get; set; }

        public string SizeName { get; set; } = null!;

        public string? High { get; set; }
        public string? Width { get; set; }
        public string? Lenght { get; set; }
    }
}
