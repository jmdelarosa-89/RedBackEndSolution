using Microsoft.OpenApi.Models;
using RedBackEndApi.Extensions;
using System.Reflection;

namespace RedBackEndApi
{
    /// <summary>
    /// Clase para configuración del API
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Interfaz del objeto Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuración de servicios
        /// </summary>                                           
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Permite la comunicacion cross-domain
            services.AddCors();

            //Configuracion de swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RedBackEndApi", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //Agrega las politicas de autorizacion al servicio
            services.AddJwtAuthorization();

            //Agrega las politicas de autenticación al servicio (Elementos del JWT que seran validados)
            services.AddJwtAuthentication(Configuration);

            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    });

            //Cuando existe un error de validación en los modelos de entrada de los endpoint
            //recolecta la informacion y la devuelve en formato JSON
            services.AddApiBehavior();
        }

        /// <summary>
        /// Configuración de la aplicación
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedBackEndApi v1"));
            }

            app.UseJsonExceptionHandler();

            app.UseForwardedHeaders();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
