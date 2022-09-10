using Microsoft.AspNetCore.Mvc;

namespace Module17_ModelsAndViews.SeparateComponents;

/// <summary>
/// Пример компонента, который определён через наследования
/// </summary>
public class SimpleComponentWithInheritance : ViewComponent
{
    public string Invoke()
    {
        return nameof(SimpleComponentWithInheritance);
    }
}