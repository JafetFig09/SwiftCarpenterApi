namespace swiftcarpenterApi.Domain.Dtos
{
    public class ColorResponseDTO
    {
        public int Id { get; set; }

        public string ColorName { get; set; } = null!;

        public string? HexadecimalCode { get; set; }
    }
}
