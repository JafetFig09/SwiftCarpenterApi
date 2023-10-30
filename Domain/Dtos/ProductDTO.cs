using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? ProductTypeName { get; set; }

        public string? MaterialName { get; set; }

        public string? FinishType { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }

        public decimal Price { get; set; }

        public string DescriptionProduct { get; set; } = null!;
    }
}
