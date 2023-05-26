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

        public User getById(Guid userId)
        {
            return userRepository.getById(userId);
        }
		public List<User> getAllUsers()
		{
			return userRepository.getAllUsers();
		}

		public User login(string email, string password)
        {
          return userRepository.Login(email,password);
        }

        public User register(User user)
        {
            return userRepository.register(user);
        }

        public User Update(User user)
        {
            var updateduser=userRepository.Update(user);
            return updateduser;
        }

	
	}
}
