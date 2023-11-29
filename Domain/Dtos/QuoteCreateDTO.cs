using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class QuoteCreateDTO
    {

        public int CustomerId { get; set; }
    
        public  ICollection<DetailQuoteCreateDTO> DetailQuotes { get; set; } = new List<DetailQuoteCreateDTO>();
    }
}
