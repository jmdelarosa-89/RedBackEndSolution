using RedBackEnd.Business.Gestores;
using RedBackEnd.Business.Modelos;

namespace RedBackEnd.Business.Interfaces
{
    /// <summary>
    /// Contrato: Establece las pautas de operacion para la gestion de usuarios
    /// </summary>
    public interface IGestorUsuarios : IRepositorio<GestorUsuarios>
    {
        /// <summary>
        /// Realiza operaciones de inicio de sesion
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<object> Login(LoginModel login);

        /// <summary>
        /// Obtiene usuario
        /// </summary>
        /// <returns></returns>
        Task<object> ObtenerUsuarioPorId(int id);

        /// <summary>
        /// Devuelve el listado filtrado y paginado de usuarios
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="numPagina"></param>
        /// <param name="longPagina"></param>
        /// <returns></returns>
        Task<ICollection<object>> ObtenerUsuarios(FiltroUsuariosModel filtro, int numPagina, int longPagina);

        /// <summary>
        /// Genera alta de la usuario
        /// </summary>
        Task<int> Guardar(UsuarioModel nvoUsuario);

        /// <summary>
        /// Permite actualizar un usuario
        /// </summary>
        Task Actualizar(UsuarioModel actUsuario);

        /// <summary>
        /// Permite eliminar un usuario
        /// </summary>        
        Task Eliminar(int usuarioId);
    }
}
