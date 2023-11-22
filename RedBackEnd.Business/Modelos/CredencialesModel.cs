using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Business.Modelos
{
    /// <summary>
    /// Objeto general de respuesta que contiene las credenciales del usuario
    /// </summary>
    public class CredencialesModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CredencialesModel()
        {
            Email = string.Empty;
            NombreUsuario = string.Empty;
            Jwt = string.Empty;
        }

        /// <summary>
        /// Correo electrónico de usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// JWT de sesion
        /// </summary>
        public string Jwt { get; set; }

    }
}
