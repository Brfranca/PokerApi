namespace Poker.Service.Interfaces.UseCases
{
    public interface IAuthenticateUseCase
    {
        Task<bool> Execute(string email, string password);
    }
}
