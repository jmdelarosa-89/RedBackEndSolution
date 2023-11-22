using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Primitives;
using RedBackEnd.Business.Modelos;
using System.Net.Mime;
using System.Net;

namespace RedBackEndApi.Extensions
{
    /// <summary>
    /// Extension para manejo de excepciones no controladas
    /// </summary>
    public static class ExceptionHandlerExtension
    {
        /// <summary>
        /// Captura las excepciones no controladas y genera una respuesta en formato JSON
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJsonExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                var logger = context.Features.Get<ILogger>();

                context.Request.Headers.TryGetValue("X-Request-ID", out StringValues requestIDSV);
                var requestID = requestIDSV.FirstOrDefault();

                HttpRequestException exp = null;
                if (exception is HttpRequestException)
                {
                    exp = (HttpRequestException)exception;
                }

                context.Response.StatusCode = exp != null ? (int)exp.StatusCode : (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                if (exception != null)
                {
                    GlobalErrorModel ged = new GlobalErrorModel(context.Response.StatusCode, exception.Message);
                    if (exception.InnerException != null)
                    {
                        ged.AgregaError(exception.InnerException.Message);
                    }

                    await context.Response.WriteAsJsonAsync(ged);
                }
            }));
            return app;
        }
    }
}
