using Microsoft.EntityFrameworkCore;
using Poker.Domain.Models;
using Poker.Domain.Repositories;
using Poker.Infra.Config;

namespace Poker.Infra.Repositories
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public async Task<UserModel?> GetByEmail(string email)
        {
            return await _set.FirstOrDefaultAsync(d => d.Email == email);
        }
    }
}
