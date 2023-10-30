using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class DetailQuoteDTO
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double subtotal { get; set; }
        public string ProductName { get; set; }
      
        public string ProductDescription { get; set; }
    }
}
