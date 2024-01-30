using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.Extensions.Logging;

namespace API.Helpers
{
    public class ExceptionMiddelware
    {
        
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddelware> _ILogger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddelware(RequestDelegate next, ILogger<ExceptionMiddelware> logger,
        IHostEnvironment env)
        {
            _env = env;
            _ILogger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _ILogger.LogError(ex,ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _env.IsDevelopment()
                    ? new ApiException((int)HttpStatusCode.InternalServerError, ex.Message,
                    ex.StackTrace.ToString()): new ApiResponse((int)HttpStatusCode.InternalServerError);
                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response,options);
                await context.Response.WriteAsync(json);

            }
        }

    }
}