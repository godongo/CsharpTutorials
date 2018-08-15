using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebMvcMovie.Infrastructure;
using WebMvcMovie.Models;


namespace WebMvcMovie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Gee: This method is NOT INJECTABLE BY DESIGN
        public void ConfigureServices(IServiceCollection services)
        {
            /*
             * 1. TRANSIENT OBJECTS are always different; a new instance is provided to every 
             *    controller and every service.
             * 2. SCOPED OBJECTS are the same within a request, 
             *    but different across different requests
             * 3. SINGLETON OBJECTS are the same for every object and every request (regardless of 
             *    whether an instance is provided in ConfigureServices)
             *
             */
            services.AddMvc();

            services.AddDbContext<WebMvcMovieContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebMvcMovieContext")));

            //services.AddDbContext<WebMvcMovieContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("WebMvcMovieContext")), ServiceLifetime.Transient);



            /**
			 * Our configuration
			 */
            services.AddOptions();
            services.Configure<ErrorHandlingOptions>(Configuration.GetSection(""));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Gee: This method is INJECTABLE BY DESIGN, we can inject predifined services by the framework.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            //app.UseCustomExceptionHandler();
            //app.UseMiddleware<GeeMiddleware>(); // Using a middleware as a standalone class.

            #region Diagnostics middleware
            //app.UseWelcomePage();
            //app.UseDeveloperExceptionPage();

            #endregion

            //app.UseFileServer();
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseNodeModules(env.ContentRootPath);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        //public void SomeMiddleware(IApplicationBuilder app, ILogger<Startup> logger)
        //{
        //    app.Use(next => {
        //        return async context =>
        //        {
        //            logger.LogInformation("Request incoming");

        //            if (context.Request.Path.StartsWithSegments("/gee"))
        //            {
        //                await context.Response.WriteAsync("Hit!!");
        //                logger.LogInformation("Request handled");
        //            }
        //            else
        //            {
        //                await next(context);
        //                logger.LogInformation("Response outgoing");
        //            }
        //        };
        //    });
        //}
    }
}
