using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Serilog;

namespace MovieShopMVC.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;
        

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/ErrorLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //_logger.LogInformation("Inside MovieShop Exception Middleware");
            //_logger.LogInformation("----------------Start----------------");

            Log.Information("Inside MovieShop Exception Middleware");
            Log.Information("----------------Start----------------");

            try
            {
                //_logger.LogInformation("No Exception");
                Log.Information("No Exception");
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogInformation("----------------StartException----------------");
                Log.Information("----------------StartException----------------");
                await HandleException(httpContext, ex);
            }
        }
        private async Task HandleException(HttpContext context, Exception ex)
        {
            //_logger.LogError("Something went wrong {0}", ex.Message);
            Log.Error("Something went wrong {0}", ex.Message);
            var errorDetails = new
            {
                ExceptionMessage = ex.Message,
                DateOccurred = DateTime.UtcNow,
                StackTrace = ex.StackTrace,
                InnerException = ex.InnerException,
                Url = context.Request.Path,
                IsAuthenticated = context.User.Identity.IsAuthenticated,
                Email = Convert.ToInt32(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
            };

            //_logger.LogInformation("----------------EndException----------------");
            Log.Information("----------------EndException----------------");
            //log to file
            context.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
