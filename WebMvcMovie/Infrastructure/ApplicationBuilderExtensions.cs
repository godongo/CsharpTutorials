using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcMovie.Infrastructure
{
    // GeeNote: This is a middleware that allows to serve assets from "node_modules"
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(
           this IApplicationBuilder builder, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);
            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;

            builder.UseStaticFiles(options);

            return builder;

            // GeeNote: Compare with the other middleware implementation. 
            //return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
