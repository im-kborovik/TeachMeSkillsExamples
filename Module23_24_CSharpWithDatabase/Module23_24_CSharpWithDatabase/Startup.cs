using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module23_24.Ado_Net;
using Module23_24.Ado_Net.Interfaces;
using Module23_24.Shared.Interfaces;

namespace Module23_24_CSharpWithDatabase
{
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

            services.AddScoped<IDefaultConnectionProvider, DefaultConnectionProvider>();
            services.AddScoped<IMasterConnectionProvider, MasterConnectionProvider>();

            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<ITableManager, AdoDotNetTableManager>();

            services.AddScoped<IUserService, AdoNetUserService>();
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
}