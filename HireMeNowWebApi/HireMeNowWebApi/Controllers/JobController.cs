using AutoMapper;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using HireMeNowWebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HireMeNowWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobController : ControllerBase
	{

		private readonly IJobService _jobService;
		private readonly IMapper _mapper;
        // GET: api/<JobController>
        public JobController(IJobService jobService, IMapper mapper )
        {
			 _jobService= jobService;
			_mapper= mapper;

		}
        [HttpGet("/job/GetJob")]
		public IActionResult GetJob()
		{
			List<Job> job = _jobService.GetJobs();
			return Ok(job);
		}
		// GET api/<JobController>/5
		[HttpGet("/job/GetJobList")]
		public IActionResult Get(string title)
		{
			List<Job> job = _jobService.getByTitle(title);
			if (job == null)
			{
				return BadRequest("User with id : " + title + " Not Found.");
				//  throw new NotFoundException("User with id : "+userId+ " Not Found.");
			}
			return Ok(job);

			
		}

		// POST api/<JobController>
		[HttpPost("/job/PostJob")]
		public IActionResult PostJob(JobDto jobDto)
		{
			var job = _mapper.Map<Job>(jobDto);
			return Ok(_jobService.PostJob(job));
			
			
		}

		// PUT api/<JobController>/5
		[HttpPut("/job/UpdateJob")]
		public IActionResult UpdateJob(JobDto jobdto)
		{
			var jobToUpdate = _mapper.Map<Job>(jobdto);
			Job job = _jobService.Update(jobToUpdate);

			return Ok(_mapper.Map<JobDto>(job));
		}

		// DELETE api/<JobController>/5
		[HttpDelete("{id}")]
		public IActionResult Remove(Guid id)
		{
			_jobService.DeleteItemById(id);
			
			return NoContent();
		}
	}
}
