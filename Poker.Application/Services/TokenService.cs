using Poker.Service.DTOs.Token;
using Poker.Service.Interfaces.Services;
using Poker.Service.Interfaces.UseCases;

namespace Poker.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IAuthenticateUseCase _authenticateUseCase;
        private readonly IGenerateTokenUseCase _generateTokenUseCase;
        public TokenService(IAuthenticateUseCase authenticateUseCase, IGenerateTokenUseCase generateTokenUseCase)
        {
            _authenticateUseCase = authenticateUseCase;
            _generateTokenUseCase = generateTokenUseCase;
        }

        //TODO azure key vault
        public async Task<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            bool authenticated = await _authenticateUseCase.Execute(tokenRequest.Email, tokenRequest.Password);

            if (!authenticated)
                throw new UnauthorizedAccessException("Senha inválida.");

            var token = _generateTokenUseCase.Execute(tokenRequest.Email);

            return new TokenResponse()
            {
                Token = token.Item1,
                Expiration = token.Item2
            };
        }
    }
}
