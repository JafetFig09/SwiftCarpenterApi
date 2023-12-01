using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace swiftcarpenterApi.Domain.Dtos
{
    public class UserCredential
    {
        [Required]
        [EmailAddress] 
        public string? Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}
