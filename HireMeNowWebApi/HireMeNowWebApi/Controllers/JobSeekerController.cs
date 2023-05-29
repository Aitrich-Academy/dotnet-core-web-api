using AutoMapper;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Repositories;
using HireMeNowWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace HireMeNowWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class JobSeekerController : ControllerBase
	{
		ICompanyService _companyService;
		ICompanyRepository _companyRepository;
		IJobService _jobService;
		IUserService _userService;
		IUserRepository _userRepository;
		IApplicationService _applicationService;
		private readonly IMapper _mapper;
		public JobSeekerController(IJobService jobService, IUserService userService, IUserRepository userRepository, IApplicationService applicationService,ICompanyService companyService,ICompanyRepository companyRepository)
		{
			_companyService = companyService;
			_jobService = jobService;
			_userService = userService;
			_userRepository = userRepository;
			_applicationService = applicationService;
			_companyRepository = companyRepository;
		}
		[HttpPost("/JobSeeker/ApplyJob")]
		public IActionResult ApplyJob(ApplicationDto applicationDto)
		{
			

			var Job=_jobService.getJobById(applicationDto.JobId.Value);
			var cmp = _userService.getById(applicationDto.UserId.Value);
			if(Job==null || cmp==null)
			{
				return BadRequest("Not valid.");
			}

				
			_applicationService.AddApplication(applicationDto.JobId.Value,applicationDto.UserId.Value);
			return Ok();

		

			
			
		}
		[HttpGet("/JobSeeker/AllApplyJobs")]
		public IActionResult AllAppliedJobs()
		{
						//HttpContext.Session.SetString("UserId", result.Id.ToString());
			List<Application> Application = _applicationService.AllAppliedjobs();

		
			return Ok(Application);
		}
		[HttpGet("/JobSeeker/AllApplyJobsByUserIdorCompanyId")]
		public IActionResult AllJobsByUserIdorCompanyId(Guid? UserId=null,Guid? CmpId=null)
		{
			if (UserId != null && CmpId==null)
			{
				var user = _userRepository.getById(UserId.Value);
				if (user == null)
				{
					return BadRequest("Not Found");
				}

				

			}

			else if (CmpId != null&& UserId==null)
			{
				var cmp = _companyRepository.getById(CmpId);

				if(cmp==null)
				{
					return BadRequest("Not found");
				}
			}
			else if(CmpId==null || UserId==null)
			{
				return Ok(_applicationService.AllAppliedjobs());
			}
			else
			{
				var cmp = _companyRepository.getById(CmpId.Value);
				var user = _userRepository.getById(UserId.Value);

				if(cmp==null||user==null)
				{
					return BadRequest("Not Found");
				}
				else
				{
					return Ok(_applicationService.AllAppliedJobsByUserIdorCompanyID(UserId, CmpId));
				}
				
			}

			return Ok(_applicationService.AllAppliedJobsByUserIdorCompanyID(UserId, CmpId));

		}

	}

}
