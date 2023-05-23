using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
    public interface IUserService
    {
        User getById(Guid userId);
        User login(string email, string password);
        User register(User user);
        User Update(User user);
    }
}
