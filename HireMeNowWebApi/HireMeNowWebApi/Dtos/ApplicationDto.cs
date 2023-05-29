using HireMeNowWebApi.Models;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HireMeNowWebApi.Dtos
{
	public class ApplicationDto
	{
		public ApplicationDto(Job job, User user, Guid? id = null)
		{
			Id = Guid.NewGuid();
			//Job.Id = job.Id;
			//User.Id = user.Id;
		}
        public ApplicationDto()
        {
            
        }

        public Guid Id { get; set; }
		public Guid? JobId { get; set; }
		public Guid? UserId { get; set; }

	


	}
}
