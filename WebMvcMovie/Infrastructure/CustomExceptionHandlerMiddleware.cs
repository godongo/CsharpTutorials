using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebMvcMovie.Infrastructure
{
    public sealed class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public ErrorHandlingOptions _options { get; }

        public CustomExceptionHandlerMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory,
            IOptions<ErrorHandlingOptions> options)
        {
            _next = next;           
            _logger = loggerFactory.
                    CreateLogger<CustomExceptionHandlerMiddleware>();
            _options = options.Value;
        }
        
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error message from middleware");

                //context.Response.Redirect("/Error/Index");
                context.Response.Redirect(_options.ErrorPageUrl);

            }
        }        
    }
}

