using System.ComponentModel.DataAnnotations;

namespace RedBackEnd.Business.Modelos
{
    /// <summary>
    /// Modelo de formulario de inicio de sesion
    /// </summary>
    public class LoginModel
    {
        public LoginModel()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        /// <summary>
        /// Correo Electronico 
        /// </summary>
        [EmailAddress(ErrorMessage = "El email es incorrecto")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email es incorrecto")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El email es obligatorio")]
        [StringLength(maximumLength: 150, ErrorMessage = "El campo email tiene una longitud máxima de 150 caracteres")]
        public string Email { get; set; }

        /// <summary>
        /// Contraseña
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "introducir una contraseña es requerido")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener minimo 8 caracteres")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "la contraseña es minimo de 8 caracteres")]
        [RegularExpression(@"^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,20}$$", ErrorMessage = "La contraseña debe tener al entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula, al menos una mayúscula y al menos un caracter no alfanumérico.")]
        public string Password { get; set; }
    }
}
