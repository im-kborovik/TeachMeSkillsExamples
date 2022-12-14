using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace DependencyInjectionExample;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
                   .ConfigureWebHostDefaults(webBuilder =>
                                             {
                                                 webBuilder.UseStartup<Startup>();
                                             })
                   .ConfigureAppConfiguration(builder =>
                                              {
                                                  builder.AddJsonFile("testuser.json");
                                              });
    }
}