using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace RedBackEndApi.Extensions
{
    /// <summary>
    /// Extension para configuracion de autenticacion de Jwt
    /// </summary>
    public static class JwtAuthenticationExtension
    {
        /// <summary>
        /// Agrega los parametros que debe cumplir el JWT para autenticar al usuario
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                        };

                        options.Events = new JwtBearerEvents
                        {
                            //Personaliza el mensaje de error por una validación fallida
                            OnChallenge = context =>
                            {
                                throw new HttpRequestException(context.Error, new Exception(context.ErrorDescription), HttpStatusCode.Unauthorized);
                            }
                        };
                    });

            return services;
        }

        /// <summary>
        /// Agrega las politicas de autorizacion al servicio
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddJwtAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.Name);
                });
            });

            return services;
        }
    }
}
