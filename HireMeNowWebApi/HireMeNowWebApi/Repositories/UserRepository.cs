using HireMeNowWebApi.Enums;
using HireMeNowWebApi.Exceptions;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User> { new User( "jobprovider", "", "jobprovider@gmail.com", 123, "123", Roles.JobProvider,new Guid("ae32ba86-8e8d-4615-aa47-7387159e705d")),
         new User( "manu", "", "manu@gmail.com", 123, "123", Roles.JobSeeker),
         new User( "rs", "", "sad@gmail.com", 123, "123", Roles.CompanyMember), new User( "arun", "", "arun@gmail.com", 123, "123", Roles.Admin)};
        public User register(User user)
        {
            user.Id = Guid.NewGuid();
            user.Role = Roles.JobSeeker;

            if (users.Find(e => e.Email == user.Email) == null)
            {
                users.Add(user);
                return user;
            }
            throw new UserAlreadyExistException(user.Email);
        }
    }
}
