namespace Module17_ModelsAndViews;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews().AddRazorRuntimeCompilation();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (!_environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(q =>
                         {
                             q.MapControllerRoute(name: "default",
                                                  pattern: "{controller=Home}/{action=Index}/{id?}");
                         });
    }
}