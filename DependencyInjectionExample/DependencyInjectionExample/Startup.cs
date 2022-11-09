using DependencyInjection.EfCoreUserManagement.Extensions;
using DependencyInjection.FileUserManagement.Extensions;
using DependencyInjection.InMemoryUserManagement.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionExample;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        
        services.AddInMemoryUserManagement();
        // services.AddUserManagementByFile();
        // services.AddEfCoreUserManagement(Configuration.GetConnectionString("DefaultConnection"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
                         {
                             endpoints.MapControllerRoute("default",
                                                          "{controller=Home}/{action=Index}/{id?}");
                         });
    }
}