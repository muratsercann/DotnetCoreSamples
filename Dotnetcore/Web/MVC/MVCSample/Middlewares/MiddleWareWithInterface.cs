
using System.Net;

namespace MVCSample.Middleware
{
    public class MiddleWareWithInterface : IMiddleware
    {
        private readonly ILogger<MiddleWareWithInterface> _logger;
        public MiddleWareWithInterface(ILogger<MiddleWareWithInterface> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogInformation($"msercan : Log : Middleware says : {ex.ToString()}");
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                await context.Response.WriteAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"msercan : Middleware says : {ex.ToString()}");
                context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                await context.Response.WriteAsync(ex.Message);

            }
        }
    }
}
