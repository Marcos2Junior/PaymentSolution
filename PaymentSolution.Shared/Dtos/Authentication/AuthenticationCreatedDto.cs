namespace PaymentSolution.Shared.Dtos.Authentication
{
    public class AuthenticationCreatedDto
    {
        public string Scope { get; set; }
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime Created { get; set; }
    }
}
