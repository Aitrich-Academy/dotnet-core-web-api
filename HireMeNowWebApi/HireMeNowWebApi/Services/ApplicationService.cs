using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Repositories;

namespace HireMeNowWebApi.Services
{
	public class ApplicationService : IApplicationService
	{
		public IUserRepository _userRepository;
		public  IJobRepository _jobRepository;
		public IApplicationRepository _applicationRepository;
		public void AddApplication(Guid JobId, Guid UserId)
		{
			User user = _userRepository.getById(UserId);
			Job job = _jobRepository.GetJobById(JobId);
			//_applicationRepository.AddApplication(user,job);
		}
	}
}
