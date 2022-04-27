namespace MicroService_Auth.Models
{
    public class AuthToken
    {
        public string Token { get; set; } = null!;
        public DateTime ExpirationDate { get; set; }
    }
}
