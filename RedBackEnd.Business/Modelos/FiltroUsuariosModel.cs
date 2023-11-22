using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Business.Modelos
{
    public class FiltroUsuariosModel
    {
        public FiltroUsuariosModel() 
        {
            Email = string.Empty;
            Nombre = string.Empty;
            ApellidoPaterno = string.Empty;
        }

        [MaxLength(20, ErrorMessage = "El correo debe ser de máximo 20 caracteres")]
        public String? Email { get; set; }

        [MaxLength(20, ErrorMessage = "El nombre debe ser de máximo 20 caracteres")]
        public String? Nombre { get; set; }

        [MaxLength(20, ErrorMessage = "El apellido paterno debe ser de máximo 20 caracteres")]
        public String? ApellidoPaterno { get; set; }
    }
}
