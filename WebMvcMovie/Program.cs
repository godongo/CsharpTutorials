using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebMvcMovie.Models;
using System;

namespace WebMvcMovie
{
    // THIS METHOD IS FOR LOW LEVEL CONFIGURATION OF THE APPLICATION.
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    // Requires using MvcMovie.Models;
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            
            /* 
             * 1. By default will load configuration based on appsettings.json
             * 2. Also adds environment variables(Runs in OS or exist outside project) 
             *    to the settings list. 
             */
            WebHost.CreateDefaultBuilder(args) 
                .UseStartup<Startup>()
                .Build();
    }
}
