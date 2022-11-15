using Bogus;
using DependencyInjection.BusinessLayer.Dtos;
using DependencyInjection.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public Task<IReadOnlyCollection<UserResponseDto>> GetUsers()
    {
        return _userService.GetUsers();
    }

    [HttpGet("{userId:guid}")]
    public Task<UserResponseDto> GetUser([FromRoute] Guid userId)
    {
        return _userService.GetUser(userId);
    }

    [HttpPost]
    public Task<UserResponseDto> AddUser([FromBody] UserRequestDto requestDto)
    {
        return _userService.AddUser(requestDto);
    }

    [HttpPost("by-form")]
    public Task<UserResponseDto> AddUserByFormData([FromForm] UserRequestDto requestDto)
    {
        return _userService.AddUser(requestDto);
    }

    [HttpPut("{userId:guid}")]
    public Task<UserResponseDto> UpdateUser([FromRoute] Guid userId, [FromBody] UserRequestDto requestDto)
    {
        return _userService.UpdateUser(userId, requestDto);
    }

    [HttpDelete("{userId:guid}")]
    public Task DeleteUser([FromRoute] Guid userId)
    {
        return _userService.DeleteUser(userId);
    }

    [HttpPost("random")]
    public Task<UserResponseDto> AddUser()
    {
        var faker = new Faker();
        return _userService.AddUser(new UserRequestDto
                                    {
                                        Email = faker.Person.Email,
                                        FirstName = faker.Person.FirstName,
                                        LastName = faker.Person.LastName,
                                        BirthDate = faker.Person.DateOfBirth
                                    });
    }

    [HttpPut("random")]
    public async Task<UserResponseDto> UpdateUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyUserId = faker.PickRandom(users.Select(q => q.UserId).ToList());

        return await _userService.UpdateUser(anyUserId,
                                             new UserRequestDto
                                             {
                                                 Email = faker.Person.Email,
                                                 FirstName = faker.Person.FirstName,
                                                 LastName = faker.Person.LastName,
                                                 BirthDate = faker.Person.DateOfBirth
                                             });
    }

    [HttpDelete("random")]
    public async Task DeleteUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyUserId = faker.PickRandom(users.Select(q => q.UserId).ToList());

        await _userService.DeleteUser(anyUserId);
    }
}