using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RedBackEnd.Business.Modelos
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            ApellidoMaterno = string.Empty;
            ApellidoPaterno = string.Empty;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
        }

        /// <summary>
        /// Id de usuario
        /// </summary>
        [Required]
        [Description("Id Usuario")]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Ap. Paterno
        /// </summary>
        [StringLength(150)]
        [Description("Ap. Paterno")]
        [Required(ErrorMessage = "El apellido paterno es obligatorio")]
        [MinLength(2, ErrorMessage = "El apellido paterno debe tener mínimo de 3 caracteres")]
        [MaxLength(150,ErrorMessage = "El apellido paterno debe tener máximo de 150 caracteres")]
        public String ApellidoPaterno { get; set; }

        /// <summary>
        /// Ap. Materno
        /// </summary>
        [StringLength(150)]
        [MinLength(2, ErrorMessage = "El apellido materno debe tener mínimo de 3 caracteres")]
        [MaxLength(150, ErrorMessage = "El apellido materno debe tener máximo de 150 caracteres")]
        public String ApellidoMaterno { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        [StringLength(150)]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MinLength(2, ErrorMessage = "El nombre debe tener mínimo de 3 caracteres")]
        [MaxLength(150, ErrorMessage = "El nombre debe tener máximo de 150 caracteres")]
        public String Nombre { get; set; }

        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Telefono 
        /// </summary>
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El valor ingresado no corresponde con un número telefónico")]
        [MaxLength(20, ErrorMessage = "El campo teléfono tiene una longitud máxima de 20 caracteres")]
        public string Telefono { get; set; }

        /// <summary>
        /// Correo Electronico 
        /// </summary>
        [EmailAddress(ErrorMessage = "El email es incorrecto")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email es incorrecto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El email es obligatorio")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo email tiene una longitud máxima de 150 caracteres")]
        public string Email { get; set; }

        public int Edad { get; set; }
    }
}
