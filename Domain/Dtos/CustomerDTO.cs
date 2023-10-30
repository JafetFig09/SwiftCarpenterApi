using SwiftCarpenter.Domain.Entities;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        //public string CustomerName { get; set; } = null!;

        //public string LastName { get; set; } = null!;

        //public string Email { get; set; } = null!;

       public virtual ICollection<QuoteDTO> Quotes { get; set; } = new List<QuoteDTO>();
    }
}
