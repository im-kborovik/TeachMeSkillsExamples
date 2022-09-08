using Microsoft.AspNetCore;
using Module17_ModelsAndViews;

#region UseWithStartup

// var builder = WebHost.CreateDefaultBuilder();
//
// builder.UseStartup<Startup>();
//
// var app = builder.Build();
// app.Run();

#endregion UseWithStartup

#region UseWithoutStartup

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default",
                       pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

#endregion UseWithoutStartup