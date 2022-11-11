namespace DependencyInjection.WebApiUserManagement.Settings;

public class WebApiSettings
{
    public const string SectionName = "WebApiSettings";

    public string BaseAddress { get; set; }

    public string GetUsers { get; set; }

    public string AddUser { get; set; }

    public string UpdateUser { get; set; }

    public string DeleteUser { get; set; }
}