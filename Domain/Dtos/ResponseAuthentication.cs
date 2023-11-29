namespace swiftcarpenterApi.Domain.Dtos
{
    public class ResponseAuthentication
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
