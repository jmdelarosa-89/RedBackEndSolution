namespace RedBackEnd.Domain.Entorno
{
    /// <summary>
    /// Modelo de conexión a la base de datos
    /// </summary>
    public class ConnectionsModel
    {
        public ConnectionsModel()
        {
            TimeOut = 0;
            Servidor = string.Empty;
        }

        /// <summary>
        /// Variable para el timeout de los queries
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// Cadena de conexion a la base de datos
        /// </summary>
        public String Servidor { get; set; }
    }
}
