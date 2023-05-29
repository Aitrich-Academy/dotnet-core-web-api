using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
	public interface IApplicationService
	{
		void AddApplication(Guid JobId, Guid UserId);
		List<Application> AllAppliedjobs();
		List<Application> AllAppliedJobsByUserIdorCompanyID(Guid? UserId = null, Guid? CmpId = null);
		
	}
}
