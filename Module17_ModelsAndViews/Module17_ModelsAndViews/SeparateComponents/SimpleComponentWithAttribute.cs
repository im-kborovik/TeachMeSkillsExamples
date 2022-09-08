using Microsoft.AspNetCore.Mvc;

namespace Module17_ModelsAndViews.SeparateComponents;

[ViewComponent]
public class SimpleComponentWithAttribute
{
    public string Invoke()
    {
        return nameof(SimpleComponentWithAttribute);
    }
}