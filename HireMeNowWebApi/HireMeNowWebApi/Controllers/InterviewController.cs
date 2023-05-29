using AutoMapper;
using AutoMapper.Configuration.Annotations;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InterviewController : ControllerBase
	{

		private readonly IInterviewServices _interviewService;
		private IJobService _jobService;
		private readonly IMapper _mapper;
		private readonly ICompanyService _companyService;	

		public InterviewController(IInterviewServices interviewService, IMapper mapper,IJobService jobService,ICompanyService companyService)
		{
			_interviewService = interviewService;
			_mapper = mapper;
			_companyService = companyService;	
			_jobService = jobService;
		}
		[HttpPost("/interview/interviewShedule")]
		public IActionResult InterviewShedule(InterviewDto interviewDto)
		{
			var job = _jobService.getJobById(interviewDto.JobId);
			var company = _companyService.getCompanyById(interviewDto.CompanyId);
			if(job == null)
			{
				return BadRequest("Job Not Found.");
			}
			if(company==null)
			{
				return BadRequest("company Not Found.");
			}

			var interview = _mapper.Map<Interview>(interviewDto);
			return Ok(_interviewService.sheduleinterview(interview));
		}
		[HttpGet("/interview/interviewSheduledlist")]
		public IActionResult InterviewSheduledList(Guid? id=null)
		{
			var cmp = _companyService.getCompanyById(id);
			if(cmp==null)
			{
				return BadRequest("Company Not Found.");
			}
			List<Interview> interviews = _interviewService.sheduledInterviewList(id);
			return Ok(interviews);

		}
		[HttpDelete("{id}")]
		public IActionResult Removeinterview(Guid id)
		{
			_interviewService.removeInterview(id);
			return NoContent();
		}
		
		

	}
}
