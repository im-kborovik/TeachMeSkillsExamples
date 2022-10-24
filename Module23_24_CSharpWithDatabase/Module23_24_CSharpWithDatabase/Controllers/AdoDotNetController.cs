using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Module23_24.Ado_Net;

namespace Module23_24_CSharpWithDatabase.Controllers
{
    public class AdoDotNetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> InitDatabase()
        {
            using var workWithDatabaseComponents1 = new WorkWithDatabaseComponents(true);
            await workWithDatabaseComponents1.CreateDatabase();

            using var workWithDatabaseComponents2 = new WorkWithDatabaseComponents();
            await workWithDatabaseComponents2.CreateUsersTableWithData();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DropDatabase()
        {
            using var workWithDatabaseComponents = new WorkWithDatabaseComponents();

            await workWithDatabaseComponents.DropDatabase();

            return RedirectToAction("Index");
        }
    }
}