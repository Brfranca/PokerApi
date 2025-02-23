using Poker.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service.Interfaces
{
    public interface IUserService
    {
        Task Create(UserRequest user);
        Task<UserResponse> GetById(int id);
        void Update(UserUpdateRequest user);
        Task UpdateAsync(UserUpdateRequest user);
    }
}
