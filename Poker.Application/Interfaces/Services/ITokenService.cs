using Poker.Service.DTOs.Token;

namespace Poker.Service.Interfaces.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
