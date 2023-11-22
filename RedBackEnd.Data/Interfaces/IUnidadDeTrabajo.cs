using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Data.Interfaces
{

    public interface IUnidadDeTrabajo : IDisposable
    {
        #region Tablas
        /// <summary>
        /// Interface: Maestro de usuarios
        /// </summary>
        ITMREDUSUARIO MtroUsuarios { get; }
        #endregion

        #region Metodos de contexto

        /// <summary>
        /// Guarda la informacion en la Base de datos
        /// conforme a las reglas de negocio
        /// </summary>
        void GuardarCambios();
        #endregion
    }
}
