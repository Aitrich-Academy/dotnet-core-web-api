using AutoMapper;
using HireMeNowWebApi.Dtos;
using HireMeNowWebApi.Models;

namespace HireMeNowWebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, User>().ReverseMap();
			CreateMap<InterviewDto, Interview>().ReverseMap();

			CreateMap<JobDto,Job>().ReverseMap();
		}
	}
}
