using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Dulichvietlao.Middlewares
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.ToLower() == "/home/adminsignin")
            {
                await _next(context);
            }
            else if (context.Request.Path.Value.ToLower() == "/home/about")
            {
                
                await _next(context);
            }
            else
            {
                var isValidRequest = false;

                var valueSession = context.Session.GetString("Account");
                context.Session.SetString("Account","valueSession");

                if (string.IsNullOrWhiteSpace(valueSession))
                {
                }
                else
                    isValidRequest = true;
                if (isValidRequest)
                {
                    // Call the next delegate/middleware in the pipeline
                    await _next(context);
                }
                else
                {
                    await context.Response.WriteAsync(@"<html><head>
                                                        <title>Access Denied</title>
                                                        </head><body>
                                                        <h1>Access Denied</h1>
 
                                                        You don't have permission to access this website.<p>
                                                        </p></body></html>");
                }
            }

        }
    }
}
