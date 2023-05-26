using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Services
{
    public class CompanyService : ICompanyService
    {
        public IUserRepository _UserRepository;

        public CompanyService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public User memberRegister(User user)
        {
            return _UserRepository.memberRegister(user);
        }

        public List<User> memberListing(Guid companyId)
        {
            return _UserRepository.memberListing(companyId);
        }
        public void memberDeleteById(Guid id)
        {
            _UserRepository.memberDeleteById(id);
        }
    }
}
