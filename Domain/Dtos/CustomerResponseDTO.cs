namespace swiftcarpenterApi.Domain.Dtos
{
    public class CustomerResponseDTO
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
