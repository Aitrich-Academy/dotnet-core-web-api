using HireMeNowWebApi.Enums;
using HireMeNowWebApi.Exceptions;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User> { new User( "jobprovider", "", "jobprovider@gmail.com", 123, "123", Roles.JobProvider,new Guid("ae32ba86-8e8d-4615-aa47-7387159e705d"),new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")),
         new User( "Yadhu", "", "yadhu.aitrich@gmail.com", 123, "123", Roles.JobSeeker,null,new Guid("1d8303fb-c1e1-4fa6-a2e1-272472b2beb4")),
         new User( "rs", "", "sad@gmail.com", 123, "123", Roles.CompanyMember),
            new User( "arun", "", "arun@gmail.com", 123, "123", Roles.Admin)};

        public User getById(Guid userId)
        {
           var user= users.Where(e=>e.Id==userId).FirstOrDefault();
            return user;
        }

        public User Login(string email, string password)
        {
           return users.Where(e=>e.Email==email && e.Password==password).FirstOrDefault();
        }

        public User register(User user)
        {
            user.Id = Guid.NewGuid();
            user.Role = Roles.JobSeeker;

            if (users.Find(e => e.Email == user.Email) == null)
            {
                users.Add(user);
                return user;
            }
            else
            {
                throw new UserAlreadyExistException(user.Email);
            }
        }

        public User Update(User updatedUser)
        {
            int indexToUpdate = users.FindIndex(item => item.Id == updatedUser.Id);
            if (indexToUpdate != -1)
            {
                // Modify the properties of the item at the found index
                users[indexToUpdate].About = updatedUser.About ?? users[indexToUpdate].About;
                users[indexToUpdate].Experiences = updatedUser.Experiences ?? users[indexToUpdate].Experiences;
                users[indexToUpdate].Educations = updatedUser.Educations ?? users[indexToUpdate].Educations;
                users[indexToUpdate].Skills = updatedUser.Skills ?? users[indexToUpdate].Skills;
                users[indexToUpdate].FirstName = updatedUser.FirstName??users[indexToUpdate].FirstName;
                users[indexToUpdate].LastName = updatedUser.LastName??users[indexToUpdate].LastName;
                users[indexToUpdate].Location = updatedUser.Location??users[indexToUpdate].Location;
                users[indexToUpdate].Gender = updatedUser.Gender??users[indexToUpdate].Gender;
                users[indexToUpdate].Phone = updatedUser.Phone==null?users[indexToUpdate].Phone : updatedUser.Phone;

            }
            else
            {
                throw new NotFoundException("User Not Found");
            }

            return users[indexToUpdate];
        }
    }
}
