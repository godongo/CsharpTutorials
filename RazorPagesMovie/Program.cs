using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RazorPagesMovie.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
            //BuildWebHost(args).Run();
        //}
        public static void Main(string[] args)
        {            
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<MovieContext>();
                    // requires using Microsoft.EntityFrameworkCore;
                    context.Database.Migrate();
                    // Requires using RazorPagesMovie.Models;
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
            WebHost.CreateDefaultBuilder(args)
            // Execution order
            // 1. Appsettings 
            // 2. Environment Variables
            // 3. Commandline Args

                .UseStartup<Startup>()
                .Build();
    }

}
