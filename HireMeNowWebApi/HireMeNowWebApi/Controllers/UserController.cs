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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService=userService;
            _mapper=mapper;
        }
        [HttpPost("/account/register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return Ok(_userService.register(user));
        }
    }
}
