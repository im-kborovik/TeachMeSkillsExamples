using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bogus;
using DependencyInjection.BusinessLayer.Dtos;
using DependencyInjection.BusinessLayer.Interfaces;
using DependencyInjectionExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userService.GetUsers();
        var result = users.Select(q => new UserViewModel
                                       {
                                           FirstName = q.FirstName,
                                           LastName = q.LastName,
                                           BirthDate = q.BirthDate,
                                           Email = q.Email,
                                       })
                          .ToArray();
        return View(result);
    }

    public async Task<IActionResult> AddUser()
    {
        var faker = new Faker();
        await _userService.AddUser(new UserRequestDto
                                   {
                                       Email = faker.Person.Email,
                                       FirstName = faker.Person.FirstName,
                                       LastName = faker.Person.LastName,
                                       BirthDate = faker.Person.DateOfBirth
                                   });

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyUserId = faker.PickRandom(users.Select(q => q.UserId).ToList());

        await _userService.UpdateUser(anyUserId,
                                      new UserRequestDto
                                      {
                                          Email = faker.Person.Email,
                                          FirstName = faker.Person.FirstName,
                                          LastName = faker.Person.LastName,
                                          BirthDate = faker.Person.DateOfBirth
                                      });

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult AddUserWithValidation()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddUserWithValidation(UserViewModel userViewModel, [FromServices] IMapper mapper)
    {
        if (ModelState.IsValid)
        {
            var requestDto = mapper.Map<UserRequestDto>(userViewModel);
            await _userService.AddUser(requestDto);
            return RedirectToAction("Index");
        }

        return View(userViewModel);
    }

    public async Task<IActionResult> DeleteUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyUserId = faker.PickRandom(users.Select(q => q.UserId).ToList());

        await _userService.DeleteUser(anyUserId);

        return RedirectToAction("Index");
    }
}