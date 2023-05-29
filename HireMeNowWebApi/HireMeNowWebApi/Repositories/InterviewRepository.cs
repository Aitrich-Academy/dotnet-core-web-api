using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using System.Collections.Generic;

namespace HireMeNowWebApi.Repositories
{
	public class InterviewRepository : IInterviewRepository
	{
		List<Interview> interviews = new List<Interview> { new Interview(new Guid(), new Guid(), "TCS", "Developer", "10/02/2023", "Mumbai", "10.00"), new Interview(new Guid(), new Guid(), "Wipro", "Developer", "11/02/2023", "EKm", "12.00"), new Interview(new Guid(), new Guid(), "anglo", "Accountant", "24/02/2023", "Tcr", "12.00") };
		public Interview shduleInterview(Interview interview)
		{
			interview.Id = Guid.NewGuid();
			interviews.Add(interview);
			return interview;
			
		}
		public List<Interview> sheduledInterviewList(Guid? id=null)
		{
			List<Interview> listofinterviews = new List<Interview>();
			
			if (id==null)
			{ 
				 listofinterviews = interviews.ToList(); 
			}
			else
			{
				listofinterviews = interviews.Where(e=>e.CompanyId==id).ToList();
			}
			return listofinterviews;
		

		}
		public void removeInterview(Guid id)
		{
			Interview interview = interviews.FirstOrDefault(e => e.Id == id);
			if(interview!=null)
			{
				interviews.Remove(interview);
			}
			
		}

	}
}
