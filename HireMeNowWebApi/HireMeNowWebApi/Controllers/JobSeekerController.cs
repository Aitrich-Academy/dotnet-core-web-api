using AutoMapper;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Repositories;
using HireMeNowWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class JobSeekerController : ControllerBase
	{

		IJobService _jobService;
		IUserService _userService;
		IUserRepository _userRepository;
		IApplicationService _applicationService;
		public JobSeekerController(IJobService jobService, IUserService userService, IUserRepository userRepository, IApplicationService applicationService)
		{
			_jobService = jobService;
			_userService = userService;
			_userRepository = userRepository;
			_applicationService = applicationService;
		}
		[HttpPost]
		public IActionResult ApplyJob(Guid jobId,Guid UserId)
		{
			if (jobId != null)
			{

				//bool res=_userService.ApplyJob(new Guid(jobId),new Guid(uid));
				_applicationService.AddApplication(jobId, UserId);

				

			}
			return NoContent();
		}
		[HttpGet("/AllJobs")]
		public IActionResult AllJobs()
		{
			var result = _userRepository.getuser();
			//HttpContext.Session.SetString("UserId", result.Id.ToString());
			List<Job> jobs = _jobService.GetJobs();

		
			return Ok(jobs);
		}

	}

}
