using AutoMapper;
using DependencyInjection.BusinessLayer.Dtos;
using DependencyInjectionExample.Models;

namespace DependencyInjectionExample.MapProfiles;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<UserViewModel, UserRequestDto>();
    }
}