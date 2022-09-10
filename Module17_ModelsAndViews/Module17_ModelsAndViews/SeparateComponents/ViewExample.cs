using Microsoft.AspNetCore.Mvc;

namespace Module17_ModelsAndViews.SeparateComponents;

/// <summary>
/// Пример компонента, который имеет backend часть и часть представления
/// </summary>
public class ViewExample : ViewComponent
{
    private static readonly string[] TestData =
    {
        "one",
        "two",
        "three"
    };
    
    public IViewComponentResult Invoke()
    {
        return View(TestData); // Тут будет использоваться ~/Views/Home/ViewExample/Default.cshtml
        // return View("ViewExample", TestData); // Тут будет использоваться ~/Views/Home/ViewExampleViewExample.cshtml
    }
}