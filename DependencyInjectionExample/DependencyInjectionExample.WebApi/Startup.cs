using DependencyInjection.EfCoreUserManagement.Extensions;
using DependencyInjectionExample.WebApi.Middlewares;

namespace DependencyInjectionExample.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen();

        services.AddEfCoreUserManagement(Configuration.GetConnectionString("DefaultConnection"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
                         {
                             c.SwaggerEndpoint("/swagger/v1/swagger.json", "InfoTest.Backend v1");
                         });

        app.UseDeveloperExceptionPage();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseEndpoints(endpoints =>
                         {
                             endpoints.MapControllers();
                         });
    }
}