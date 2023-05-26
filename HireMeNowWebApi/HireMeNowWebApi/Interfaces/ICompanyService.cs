using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
    public interface ICompanyService
    {
        User memberRegister(User user);
        public List<User> memberListing(Guid companyId);
        void memberDeleteById(Guid id);

    }
}
