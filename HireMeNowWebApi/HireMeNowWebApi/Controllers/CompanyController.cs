using AutoMapper;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Interfaces;
using HireMeNowWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNowWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpPost("/company/memberRegister")]
        public IActionResult memberRegister(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return Ok(_companyService.memberRegister(user));
        }

        [HttpGet("/company/memberListing")]
        public IActionResult memberListing(Guid companyId) 
        {
            var companyMembers = _companyService.memberListing(companyId);

            return Ok(_mapper.Map<List<UserDto>>(companyMembers));
            
        }
    }
}
