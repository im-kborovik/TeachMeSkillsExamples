using Microsoft.AspNetCore.Mvc;

namespace Module17_ModelsAndViews.SeparateComponents;

public class ViewExampleViewComponent : ViewComponent
{
    private static readonly string[] TestData =
    {
        "one",
        "two",
        "three"
    };
    
    public IViewComponentResult Invoke()
    {
        return View("ViewExample", TestData);
    }
}