using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvcMovie.Infrastructure
{
    // THIS SHOULD BE ADDED AS AN EXTENSION METHOD FOR IAPPLICATIONBUILDER INTERFACE.
    public class GeeMiddleware
    {
        // Remember that all contructor injected objects are handled my framework DI.
        private RequestDelegate _next;

        public GeeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Request logic goes here......

            await _next.Invoke(context);

            // Response logic goes here......
        }
    }
}
