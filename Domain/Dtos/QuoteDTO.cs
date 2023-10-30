using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class QuoteDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        public DateTime DateQuote { get; set; }

        public string? CustomerName { get; set; }

        public decimal Total { get; set; }
        public DateTime? SaleDate { get; set; }

        //public string ProductName { get; set; }
        public virtual ICollection<DetailQuoteDTO> DetailQuotes { get; set; } = new List<DetailQuoteDTO>();

    }
}
