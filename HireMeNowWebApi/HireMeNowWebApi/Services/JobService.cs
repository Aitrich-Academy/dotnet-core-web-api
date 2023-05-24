using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Repositories;

namespace HireMeNowWebApi.Services
{
    public class JobService : IJobService
    {
        IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository )
        {
            _jobRepository=jobRepository;
        }

	
			
		public void DeleteItemById(Guid id)
		{
			_jobRepository.DeleteById(id);

		}

		public List<Job> getByTitle(string title)
		{
			
				return _jobRepository.getByTitle(title);
		

		}

		public Job getJobById(Guid selectedJobId)
		{
			return _jobRepository.GetJobById(selectedJobId);
		}

		public List<Job> GetJobs()
        {
           return _jobRepository.GetJobs();
        }

		

		public Job PostJob(Job job)
        {
			return _jobRepository.PostJob(job);
        }

		public Job Update(Job job)
		{
			var updatedjob = _jobRepository.Update(job);
			return updatedjob;
		}
	}
}
