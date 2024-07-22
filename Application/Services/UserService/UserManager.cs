using Application.Repositories;
using Domain.Entities;

namespace Application.Services.UserService
{
    public class UserManager  : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetAsync(p => p.Email == email);
        }
    }
}
