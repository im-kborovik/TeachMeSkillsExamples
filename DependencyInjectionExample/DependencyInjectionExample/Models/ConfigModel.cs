namespace DependencyInjectionExample.Models;

public class ConfigModel
{
    public int TopSectionElement { get; set; }

    public int NestedSectionElement { get; set; }

    public UserViewModel ObjectSectionElement { get; set; }
    public UserViewModel ObjectSectionElementByOptions { get; set; }
}