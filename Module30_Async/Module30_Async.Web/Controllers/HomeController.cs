using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Module30_Async.Web.Models;

namespace Module30_Async.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ParallelTaskExecution()
    {
        Task.Run(async () =>
                 {
                     await Task.Delay(3000);

                     _logger.LogInformation("{Time:mm:ss}. Here is in delayed task.", DateTime.UtcNow);
                 }); // так мы отпускаем таску и продолжаем выполнение кода, а таска закончит свою работу в другом потоке незаввисимо от текущего

        _logger.LogInformation("{Time:mm:ss}. Here is finish of {Method}", DateTime.UtcNow.ToString("mm:ss"), nameof(ParallelTaskExecution));
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> SequentialTaskExecution()
    {
        await Task.Run(async () =>
                       {
                           await Task.Delay(3000);

                           _logger.LogInformation("{Time:mm:ss}. Here is in delayed task.", DateTime.UtcNow);
                       }); // здесь тоже таска будет выполнятся в другом потоке, но код не продолжит выполнение пока не выполнится таска

        _logger.LogInformation("{Time:mm:ss}. Here is finish of {Method}", DateTime.UtcNow.ToString("mm:ss"), nameof(SequentialTaskExecution));
        return RedirectToAction("Index");
    }
}