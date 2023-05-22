using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
    public interface IUserRepository
    {
        User register(User user);
    }
}
