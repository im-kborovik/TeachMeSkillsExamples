using DependencyInjection.BusinessLayer.Extensions;
using DependencyInjection.Data.Extensions;
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

        // services.AddInMemoryUserManagement();

        // services.AddUserManagementByFile();

        services.AddBusinessLayerServices(Configuration.GetConnectionString("DefaultConnection"));

        // services.AddHttpClient();
        // services.AddWebApiUserManagement(Configuration);

        // services.Configure<UserViewModel>(Configuration.GetSection("ObjectSectionElement"));
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