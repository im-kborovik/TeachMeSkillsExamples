using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkingWithEfCore.Database;

namespace WorkingWithEfCore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Различия между IEnumerable и IQueryable
        
        // using var context = new MyDbContext();

        // var root = context.Users
        //                   .AsNoTracking()
        //                   .Where(q => q.UserId == 1);
        // var temp1 = root.AsEnumerable();
        // var users1 = temp1.Where(q => q.Age > 18).ToArray();
        // var users2 = root.Where(q => q.Age > 18).ToArray();
        
        return View();
    }
}