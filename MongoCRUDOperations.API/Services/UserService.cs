using MongoCRUDOperations.API.Models;
using MongoCRUDOperations.API.Repositories;

namespace MongoCRUDOperations.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateAsync(User user)
        {
            return _userRepository.CreateAsync(user);
        }

        public Task DeleteAsync(string id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _userRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(string id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(string id, User user)
        {
            return _userRepository.UpdateAsync(id, user);
        }
    }
}
