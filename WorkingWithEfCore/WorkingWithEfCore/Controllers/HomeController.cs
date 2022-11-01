using Microsoft.AspNetCore.Mvc;

namespace WorkingWithEfCore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}