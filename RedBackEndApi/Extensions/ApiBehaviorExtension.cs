using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using RedBackEnd.Business.Modelos;

namespace RedBackEndApi.Extensions
{
    /// <summary>
    /// Extension para configurar el comportamiento de una validacion de modelo erronea
    /// </summary>
    public static class ApiBehaviorExtension
    {
        /// <summary>
        /// Metodo para establecer el comportamiento
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errorList = context.ModelState.Values
                        .Where(e => e.Errors.Count > 0)
                        .SelectMany(e => e.Errors)
                        .Select(e => e.ErrorMessage)
                        .ToList();

                    GlobalErrorModel ged = new GlobalErrorModel(StatusCodes.Status400BadRequest, "Ocurrió un error de validación");
                    ged.AgregaErrores(errorList);

                    return new BadRequestObjectResult(ged);
                };
            });

            return services;
        }
    }
}
