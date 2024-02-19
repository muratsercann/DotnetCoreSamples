using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace MVCSample.Middlewares
{
    public static class ExceptionHandlingMiddleWare
    {
        public static IApplicationBuilder ConfigureExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async (context) =>
                {
                    var feature = context.Features.Get<IExceptionHandlerPathFeature>();

                    context.Response.StatusCode = (int)HttpStatusCode.Ambiguous;
                    context.Response.ContentType = System.Net.Mime.MediaTypeNames.Text.Plain;

                    if (feature?.Error is OperationCanceledException ex) //Custom exception (Validation)
                    {
                        Console.WriteLine($"msercan : OperationCanceledException in ConfigureExceptionHandling");
                        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                        await context.Response.WriteAsync("msercan : "+ ex.Message); //Custom Model
                    }
                    else if (feature?.Error is Exception otherEx)
                    {
                        Console.WriteLine($"msercan : {otherEx.GetType()} in ConfigureExceptionHandling");
                        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                        await context.Response.WriteAsync("msercan : WriteAsync " + otherEx.Message);  //Custom

                    }
                });
            });

            return app;
        }
    }
}
