using DependencyInjectionExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DependencyInjectionExample.Controllers;

public class ConfigController : Controller
{
    private readonly IConfiguration _configuration;

    public ConfigController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IActionResult GetConfigs([FromServices] IOptions<UserViewModel> options)
    {
        return View(new ConfigModel
                    {
                        TopSectionElement = _configuration.GetSection("TopSectionElement").Get<int>(),
                        NestedSectionElement = _configuration.GetSection("NestedSectionElement:NestedField").Get<int>(),
                        ObjectSectionElement = _configuration.GetSection("ObjectSectionElement").Get<UserViewModel>(),
                        ObjectSectionElementByOptions = options.Value
                    });
    }
}