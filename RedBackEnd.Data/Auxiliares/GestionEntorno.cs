using RedBackEnd.Domain.Entorno;
using System.Text;
using Newtonsoft.Json;

namespace RedBackEnd.Data.Auxiliares
{
    public class GestionEntorno
    {
        /// <summary>
        /// Modelo de Datos principal el cual contiene 
        /// las definiciones del archivo appsettings.json
        /// </summary>
        public static GestionEntornosModel Configuracion { get; set; }

        /// <summary>
        /// Provee la cadena de conexion base obtenida del archivo de configuracion
        /// NetCore:=> appsettings.json
        /// MVC :=> web.config
        /// </summary>
        private static string ConnectionString = "";

        /// <summary>
        /// Cadena de conexion configurada
        /// </summary>
        public static string CadenaConexion
        {
            get
            {
                if (Configuracion == null)
                {
                    Inicializar();
                }
                if (ConnectionString.Length <= 0)
                {
                    ConnectionString = Configuracion.ConnectionStrings.Servidor;
                }
                return ConnectionString;
            }
        }

        /// <summary>
        /// Permite cargar o refrescar el modelo de Gestion de entornos
        /// </summary>
        public static void Inicializar()
        {
            string[] path1 = Directory.GetCurrentDirectory().Split(new string[] { ".Data" }, StringSplitOptions.None);
            string path = Path.Combine(path1[0], "appsettings.json");
            string JsonFile = File.ReadAllText(path, Encoding.UTF8);
            Configuracion = JsonConvert.DeserializeObject<GestionEntornosModel>(JsonFile);
        }
    }
}
