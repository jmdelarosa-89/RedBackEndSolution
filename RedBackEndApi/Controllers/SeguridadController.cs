using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedBackEnd.Business.Contratos;
using RedBackEnd.Business.Modelos;
using System.Net;
using System.Net.Mime;

namespace RedBackEndApi.Controllers
{
    /// <summary>
    /// Controlador de las funciones de seguridad
    /// </summary>
    [ApiController]
    [Route("API/Seguridad")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class SeguridadController : BaseController
    {
        #region Propiedades
        private readonly CtoUsuarios Contrato;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa los contratos del controlador
        /// </summary>
        public SeguridadController()
        {
            Contrato = new CtoUsuarios();
        }
        #endregion

        #region Endpoints
        /// <summary>
        /// Función para inicio de sesion
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                var credenciales = await Contrato.GestionUsuarios.Login(login);
                return Ok(new ResponseModel((int)HttpStatusCode.OK, "OK", credenciales));
            }
            catch (HttpRequestException ex)
            {
                return GeneraObjectResult(ex);
            }
        }
        #endregion
    }
}
