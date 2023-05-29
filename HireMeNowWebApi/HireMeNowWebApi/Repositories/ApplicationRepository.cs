using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Repositories
{
	public class ApplicationRepository: IApplicationRepository
	{

		List<Application> _applications = new List<Application>();
		List<Application> newlist_ = new List<Application>();
		public List<Application> AllAppliedjobs()
		{
			return _applications.ToList();
		}
		public void AddApplication(User user, Job job)
		{
			_applications.Add(new Application(job, user, "Pending"));
		}
	
		public List<Application> AllAppliedJobsByUserIdorCompanyID(Guid? UserId = null, Guid? CmpId = null)
		{
			if(UserId==null)
			{
				if(CmpId!=null)
				{
					newlist_ = _applications.Where(e=>e.Job.CompanyId==CmpId).ToList();
				}
			}
			else if(CmpId==null)
			{
				if(UserId!=null)
				{
					newlist_ = _applications.Where(e=>e.User.Id==UserId).ToList();
				}
			}
			else if(UserId!=null && CmpId!=null)
			{
				newlist_ = _applications.Where(e => e.User.Id==UserId && e.Job.CompanyId==CmpId).ToList();

			}
			else
			{
				newlist_=_applications.ToList();
			}
			return newlist_;




		}
	}
}
