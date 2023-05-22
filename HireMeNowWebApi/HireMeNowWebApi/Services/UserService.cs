using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Services
{
    public class UserService : IUserService
    {
        public IUserRepository userRepository;
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public User register(User user)
        {
            return userRepository.register(user);
        }
    }
}
