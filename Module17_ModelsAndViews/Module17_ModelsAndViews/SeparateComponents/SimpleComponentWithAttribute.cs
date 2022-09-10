using Microsoft.AspNetCore.Mvc;

namespace Module17_ModelsAndViews.SeparateComponents;

/// <summary>
/// Пример компонента, который определён через атрибут
/// </summary>
[ViewComponent]
public class SimpleComponentWithAttribute
{
    public string Invoke()
    {
        return nameof(SimpleComponentWithAttribute);
    }
}