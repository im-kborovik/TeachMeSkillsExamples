using System.Linq;
using System.Threading.Tasks;
using Bogus;
using DependencyInjection.InMemoryUserManagement.Interfaces;
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
        await _userService.AddUser(faker.Person.Email, faker.Person.FirstName, faker.Person.LastName, faker.Person.DateOfBirth);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyEmail = faker.PickRandom(users.ToList()).Email;

        await _userService.UpdateUser(anyEmail, faker.Person.FirstName, faker.Person.LastName, faker.Person.DateOfBirth);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteUser()
    {
        var users = await _userService.GetUsers();
        var faker = new Faker();
        var anyEmail = faker.PickRandom(users.ToList()).Email;

        await _userService.DeleteUser(anyEmail);

        return RedirectToAction("Index");
    }
}