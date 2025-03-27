using Poker.Service.DTOs.Token;

namespace Poker.Service.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GenerateToken(TokenRequest tokenRequest);
        bool Validate(TokenRequest tokenRequest);
    }
}
