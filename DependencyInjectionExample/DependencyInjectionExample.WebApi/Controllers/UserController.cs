using Bogus;
using DependencyInjection.Entities.Users;
using DependencyInjection.InMemoryUserManagement.Interfaces;
using DependencyInjectionExample.WebApi.Dtos;
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
    public async Task<IReadOnlyCollection<UserResponseDto>> GetUsers()
    {
        var users = await _userService.GetUsers();
        return users.Select(ToUserResponse)
                    .ToArray();
    }

    [HttpPost("{email}")]
    public async Task<UserResponseDto> AddUser([FromRoute] string email, [FromBody] UserRequestDto requestDto)
    {
        var user = await _userService.AddUser(email, requestDto.FirstName, requestDto.LastName, requestDto.BirthDate);

        return ToUserResponse(user);
    }

    [HttpPost("{email}/by-form")]
    public async Task<UserResponseDto> AddUserByFormData([FromRoute] string email, [FromForm] UserRequestDto requestDto)
    {
        var user = await _userService.AddUser(email, requestDto.FirstName, requestDto.LastName, requestDto.BirthDate);

        return ToUserResponse(user);
    }

    [HttpPut("{email}")]
    public async Task<UserResponseDto> UpdateUser([FromRoute] string email, [FromBody] UserRequestDto requestDto)
    {
        var user = await _userService.UpdateUser(email, requestDto.FirstName, requestDto.LastName, requestDto.BirthDate);

        return ToUserResponse(user);
    }

    [HttpDelete("{email}")]
    public Task DeleteUser([FromRoute] string email)
    {
        return _userService.DeleteUser(email);
    }

    [HttpPost("random")]
    public async Task<UserResponseDto> AddUser()
    {
        var faker = new Faker();
        var user = await _userService.AddUser(faker.Person.Email, faker.Person.FirstName, faker.Person.LastName, faker.Person.DateOfBirth);

        return ToUserResponse(user);
    }

    [HttpPut("random")]
    public async Task<UserResponseDto> UpdateUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyEmail = faker.PickRandom(users.ToList()).Email;

        var user = await _userService.UpdateUser(anyEmail, faker.Person.FirstName, faker.Person.LastName, faker.Person.DateOfBirth);

        return ToUserResponse(user);
    }

    [HttpDelete("random")]
    public async Task DeleteUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyEmail = faker.PickRandom(users.ToList()).Email;

        await _userService.DeleteUser(anyEmail);
    }

    private static UserResponseDto ToUserResponse(User user) =>
        new()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDate = user.BirthDate,
            Email = user.Email,
        };
}