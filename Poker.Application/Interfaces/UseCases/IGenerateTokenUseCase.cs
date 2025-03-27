namespace Poker.Service.Interfaces.UseCases
{
    public interface IGenerateTokenUseCase
    {
        (string, DateTime) Execute(string email);
    }
}
