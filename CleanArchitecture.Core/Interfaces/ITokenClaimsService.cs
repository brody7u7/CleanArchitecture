namespace CleanArchitecture.Core.Interfaces
{
    public interface ITokenClaimsService
    {
        public TokenResponse GenerateToken(Models.Identity identity);
    }

    public class TokenResponse
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
