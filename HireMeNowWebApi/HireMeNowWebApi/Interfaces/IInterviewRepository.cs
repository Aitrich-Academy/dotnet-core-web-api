using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
	public interface IInterviewRepository
	{
		Interview shduleInterview(Interview interview);
		List<Interview> sheduledInterviewList(Guid? id=null);
		void removeInterview(Guid id);
		
	}
}
