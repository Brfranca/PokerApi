using Microsoft.EntityFrameworkCore;
using Poker.Domain.Models;
using Poker.Domain.Repositories;
using Poker.Infra.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Infra.Repositories
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }
    }
}
