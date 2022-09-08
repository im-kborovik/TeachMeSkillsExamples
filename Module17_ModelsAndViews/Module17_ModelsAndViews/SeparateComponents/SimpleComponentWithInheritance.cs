using Microsoft.AspNetCore.Mvc;
using Module17_ModelsAndViews.ViewComponents;

namespace Module17_ModelsAndViews.SeparateComponents;

public class SimpleComponentWithInheritance : ViewComponent
{
    public string Invoke()
    {
        return nameof(SimpleComponentWithInheritance);
    }
}