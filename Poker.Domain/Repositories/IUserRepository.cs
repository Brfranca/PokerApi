using Poker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
    }
}
