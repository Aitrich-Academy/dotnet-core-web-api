using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
	public interface IApplicationRepository
	{
		public List<Application> GetAll(Guid userId);
		public void AddApplication(User user, Job job);
	}
}
