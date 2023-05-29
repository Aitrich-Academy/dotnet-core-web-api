using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Repositories;

namespace HireMeNowWebApi.Services
{
	public class InterviewServices : IInterviewServices
	{
		public IInterviewRepository interviewRepository;

		public InterviewServices(IInterviewRepository interviewRepository)
		{
			this.interviewRepository = interviewRepository;
		}

		public void removeInterview(Guid id)
		{
			interviewRepository.removeInterview(id);
		}

		public List<Interview> sheduledInterviewList(Guid? id=null)
		{
			return interviewRepository.sheduledInterviewList(id);
		}

		public Interview sheduleinterview(Interview interview)
		{
			return interviewRepository.shduleInterview(interview);
		}
	
	}
}
