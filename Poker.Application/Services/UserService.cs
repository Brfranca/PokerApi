using AutoMapper;
using Poker.Domain.Models;
using Poker.Domain.Repositories;
using Poker.Infra.Config;
using Poker.Service.DTOs.User;
using Poker.Service.Interfaces;

namespace Poker.Service.Services
{
    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(Context context, IUserRepository userRepository, IMapper mapper)
        {
            this._context = context;
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task Create(UserRequest user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            await _userRepository.AddAsync(userModel);
            await _context.SaveChangesAsync(); //TODO metodo para validar a transação
        }

        public async Task<UserResponse> GetById(int id)
        {
            var userModel = await _userRepository.FindAsync(id);
            return _mapper.Map<UserResponse>(userModel);
        }

        public void Update(UserUpdateRequest user)
        {
            var userModel = _mapper.Map<UserModel>(user);
            _userRepository.Update(userModel);
            _context.SaveChanges(); //TODO metodo para validar a transação
        }

        public async Task UpdateAsync(UserUpdateRequest user)
        {
            await _userRepository.UpdateWhereAsync(d => d.Id == user.Id,
                e => e.SetProperty(x => x.Name, x => user.Name)
                .SetProperty(x => x.Password, x => user.Password));
        }
    }
}
