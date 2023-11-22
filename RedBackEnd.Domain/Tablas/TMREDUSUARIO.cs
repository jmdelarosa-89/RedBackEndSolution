using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RedBackEnd.Domain.Tablas
{
    /// <summary>
    /// Modelo maestro de usuarios
    /// </summary>
    public class TMREDUSUARIO
    {
        public TMREDUSUARIO()
        {
            ApellidoMaterno = string.Empty;
            ApellidoPaterno = string.Empty;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96";
        }

        /// <summary>
        /// Id de usuario
        /// </summary>
        [Required]
        [Description("Id Usuario")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Apellido paterno
        /// </summary>
        [Required]
        [StringLength(150)]
        public String ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido paterno
        /// </summary>
        [Required]
        [StringLength(150)]
        public String ApellidoMaterno { get; set; }

        /// <summary>
        /// Apellido paterno
        /// </summary>
        [Required]
        [StringLength(150)]
        public String Nombre { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [Required]
        public DateTime FechaNacimiento { get; set; }

        // <summary>
        /// Numero telefonico
        /// </summary>
        [Required]
        [StringLength(20)]
        public String Telefono { get; set; }

        /// <summary>
        /// Correo Electronico
        /// </summary>
        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress, ErrorMessage = "La estructura del correo no es correcta")]
        public String Email { get; set; }

        /// <summary>
        /// Password de acceso al sistema
        /// </summary>
        [Required]
        [StringLength(500)]
        public String Password { get; set; }
    }
}