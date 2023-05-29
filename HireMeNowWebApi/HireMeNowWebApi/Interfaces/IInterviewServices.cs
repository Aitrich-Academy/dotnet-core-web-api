using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Interfaces
{
	public interface IInterviewServices
	{
		Interview sheduleinterview(Interview interview);
		List<Interview> sheduledInterviewList(Guid? id=null);
		void removeInterview(Guid id);

	}
}
