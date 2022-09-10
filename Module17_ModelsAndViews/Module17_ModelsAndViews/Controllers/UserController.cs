using Microsoft.AspNetCore.Mvc;
using Module17_ModelsAndViews.ViewModels;

namespace Module17_ModelsAndViews.Controllers;

public class UserController : Controller
{
    private static readonly List<UserViewModel> UserViewModels = new List<UserViewModel>
                                                                 {
                                                                     new UserViewModel
                                                                     {
                                                                         Name = "Sasha",
                                                                         Age = 23,
                                                                         Email = "sasha@gamil.com"
                                                                     },
                                                                     new UserViewModel
                                                                     {
                                                                         Name = "Ira",
                                                                         Age = 34,
                                                                         Email = "ira@gamil.com"
                                                                     },
                                                                     new UserViewModel
                                                                     {
                                                                         Name = "Edvard",
                                                                         Age = 80,
                                                                         Email = "edvard@gamil.com"
                                                                     },
                                                                 };

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetUsers()
    {
        return View(UserViewModels);
    }

    [HttpGet]
    public IActionResult GetUser()
    {
        var user = UserViewModels[0];
        return View(user);
    }

    [HttpGet]
    public IActionResult AddUser()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddUser(UserViewModel model)
    {
        UserViewModels.Add(model);
        return RedirectToAction("GetUsers");
    }
}