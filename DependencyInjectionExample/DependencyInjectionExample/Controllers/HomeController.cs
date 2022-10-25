using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}