using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Module23_24.Ado_Net.Interfaces;
using Module23_24.Shared.Interfaces;

namespace Module23_24_CSharpWithDatabase.Controllers
{
    public class AdoDotNetController : Controller
    {
        private readonly IDatabaseService _databaseService;
        private readonly ITableManager _tableManager;
        private readonly IUserService _userService;

        public AdoDotNetController(IDatabaseService databaseService, ITableManager tableManager, IUserService userService)
        {
            _databaseService = databaseService;
            _tableManager = tableManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> InitDatabase()
        {
            _databaseService.EnsureDatabase();

            await _tableManager.CreateUsersTableWithData();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DropDatabase()
        {
            await _databaseService.DropDatabase();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();

            return View(users);
        }
    }
}