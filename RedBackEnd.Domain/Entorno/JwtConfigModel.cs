namespace RedBackEnd.Domain.Entorno
{
    /// <summary>
    /// Modelo de configuración para token JWT
    /// </summary>
    public class JwtConfigModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public JwtConfigModel()
        {
            Issuer = string.Empty;
            Audience = string.Empty;
            Key = string.Empty;
        }

        /// <summary>
        /// Variable para el autor del token
        /// </summary>
        public String Issuer { get; set; }

        /// <summary>
        /// Variable para la audiencia a la que se expide el token
        /// </summary>
        public String Audience { get; set; }

        /// <summary>
        /// Llave privada para firmar el token
        /// </summary>
        public String Key { get; set; }
    }
}
