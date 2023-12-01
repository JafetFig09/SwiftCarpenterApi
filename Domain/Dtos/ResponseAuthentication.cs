namespace swiftcarpenterApi.Domain.Dtos
{
    public class ResponseAuthentication
    {
        public string? Token { get; set; } 
        public DateTime Expiration { get; set; }
    }
}
