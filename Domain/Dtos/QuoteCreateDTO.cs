using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class QuoteCreateDTO
    {

        public int CustomerId { get; set; }
        public DateTime DateQuote { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<DetailQuote> DetailQuotes { get; set; } = new List<DetailQuote>();
    }
}
