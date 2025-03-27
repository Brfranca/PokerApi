using Poker.Service.DTOs.User;

namespace Poker.Service.Interfaces.Services
{
    public interface IUserService
    {
        Task Create(UserRequest user);
        Task<UserResponse> GetById(int id);
        void Update(UserUpdateRequest user);
        Task UpdateAsync(UserUpdateRequest user);
    }
}
