using Poker.Domain.Models;

namespace Poker.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task<UserModel?> GetByEmail(string email);
    }
}
