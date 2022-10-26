using Microsoft.AspNetCore.Mvc;

namespace Module23_24_CSharpWithDatabase.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}