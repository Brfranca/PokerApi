using Poker.Domain.Repositories;
using Poker.Service.Interfaces.UseCases;

namespace Poker.Service.UseCases
{
    public class AuthenticateUseCase : IAuthenticateUseCase
    {
        private readonly IUserRepository _userRepository;
        public AuthenticateUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Execute(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                throw new NullReferenceException("Usuário ou senha inválidos.");

            var user = await _userRepository.GetByEmail(email);
            if (user == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
    }
}
