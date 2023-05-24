using AutoMapper;
using HireMeNowWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class JobSeekerController : ControllerBase
	{
		private readonly IApplicationService _applicationService;
		private readonly IMapper _mapper;

		public JobSeekerController(IApplicationService applicationService, IMapper mapper)
		{
			_applicationService = applicationService;
			_mapper = mapper;
		}
		[HttpPost]
		public IActionResult ApplyJob(string jobId = null)
		{
			if (jobId != null)
			{
				var uid = HttpContext.Session.GetString("UserId");
				//    Job job = _jobService.getJobById(new Guid(jobId));
				//bool res=_userService.ApplyJob(new Guid(jobId),new Guid(uid));
				_applicationService.AddApplication(new Guid(jobId), new Guid(uid));

				//if (res)
				//            {
				return RedirectToAction("MyApplications");
				//}

			}
			return RedirectToAction("AllJobs");
		}

	}
}
