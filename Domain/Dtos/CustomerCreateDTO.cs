using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class CustomerCreateDTO
    {
        [Required]
        public string CustomerName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress(ErrorMessage = "{0} It is not a valid email")]
        public string Email { get; set; } = null!;
        [PasswordPropertyText]
        public string PasswordCustomer { get; set; } = null!;
    }
}
