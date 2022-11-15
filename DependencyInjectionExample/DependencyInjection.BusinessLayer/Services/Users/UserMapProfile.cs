using AutoMapper;
using DependencyInjection.BusinessLayer.Dtos;
using DependencyInjection.Entities.Users;

namespace DependencyInjection.BusinessLayer.Services.Users;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<UserRequestDto, User>();
        CreateMap<User, UserResponseDto>();
    }
}