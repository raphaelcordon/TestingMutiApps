using AutoMapper;
using WebApi.Infrastructure.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();
			CreateMap<UpdateUserDto, User>();
		}
    }
}
