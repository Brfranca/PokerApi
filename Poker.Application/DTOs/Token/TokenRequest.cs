namespace Poker.Service.DTOs.Token
{
    public class TokenRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
