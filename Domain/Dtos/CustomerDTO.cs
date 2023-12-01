using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }
       public  ICollection<QuoteDTO> Quotes { get; set; } = new List<QuoteDTO>();
    }
}
