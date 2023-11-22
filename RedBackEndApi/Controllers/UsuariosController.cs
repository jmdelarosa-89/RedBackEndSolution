using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedBackEnd.Business.Contratos;
using RedBackEnd.Business.Modelos;
using System.Net;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace RedBackEndApi.Controllers
{
    /// <summary>
    /// Controlador de operaciones con usuarios
    /// </summary>
    [ApiController]
    [Route("API")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UsuariosController : BaseController
    {
        #region Propiedades
        private readonly CtoUsuarios Contrato;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa los contratos
        /// </summary>
        public UsuariosController()
        {
            Contrato = new CtoUsuarios();
        }
        #endregion

        /// <summary>
        /// Devuelve un listado filtrado y paginado
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="numPagina"></param>
        /// <param name="longPagina"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Usuarios")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PaginaUsuarios([FromQuery] FiltroUsuariosModel filtro, [FromQuery] int numPagina = 1, [FromQuery] int longPagina = 5)
        {
            try
            {
                var usuarios = await Contrato.GestionUsuarios.ObtenerUsuarios(filtro,numPagina,longPagina);
                return Ok(new ResponseModel((int)HttpStatusCode.OK, "OK", usuarios));
            }
            catch (HttpRequestException ex)
            {
                return GeneraObjectResult(ex);
            }
        }

        /// <summary>
        /// Funcion para registrar nuevos usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPost]
        [Route("Usuario")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> CreaUsuario([FromBody] UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new BadHttpRequestException("Favor de validar los datos ingresados");
                }

                int usuarioId = await Contrato.GestionUsuarios.Guardar(usuario);
                return Created("ObtenerUsuario", new ResponseModel((int)HttpStatusCode.Created, "Usuario registrado correctamente", new { UsuarioId = usuarioId}));
            }
            catch (HttpRequestException ex)
            {
                return GeneraObjectResult(ex);
            }
        }

        /// <summary>
        /// Actualiza un usuario existente
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpPut]
        [Route("Usuario")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ActualizaUsuario([FromBody] UsuarioModel usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new BadHttpRequestException("Favor de validar los datos ingresados");
                }

                await Contrato.GestionUsuarios.Actualizar(usuario);
                return Ok(new ResponseModel((int)HttpStatusCode.OK, "Usuario actualizado"));
            }
            catch (HttpRequestException ex)
            {
                return GeneraObjectResult(ex);
            }
        }

        /// <summary>
        /// Elimina un usuario existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Usuario/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> EliminaUsuario(int id)
        {
            try
            {
                await Contrato.GestionUsuarios.Eliminar(id);
                return NoContent();
            }
            catch (HttpRequestException ex)
            {
                return GeneraObjectResult(ex);
            }
        }

        /// <summary>
        /// Obtiene un usuario en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Usuario/{id}", Name = "ObtenerUsuario")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ObtenerUsuario(int id)
        {
            try
            {
                var usuario = await Contrato.GestionUsuarios.ObtenerUsuarioPorId(id);
                return Ok(new ResponseModel((int)HttpStatusCode.OK, "OK", usuario));
            }
            catch (HttpRequestException ex)
            {
                return GeneraObjectResult(ex);
            }
        }
    }
}
