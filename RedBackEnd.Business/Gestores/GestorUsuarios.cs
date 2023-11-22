using Microsoft.IdentityModel.Tokens;
using RedBackEnd.Business.Exceptions;
using RedBackEnd.Business.Interfaces;
using RedBackEnd.Business.Modelos;
using RedBackEnd.Data.Auxiliares;
using RedBackEnd.Domain.Tablas;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RedBackEnd.Business.Gestores
{
    public class GestorUsuarios : GestorGeneral, IGestorUsuarios
    {
        #region Propiedades
        private readonly JwtSecurityTokenHandler JwtTokenHandler;
        #endregion

        #region Constructor
        public GestorUsuarios()
        {
            JwtTokenHandler = new JwtSecurityTokenHandler();
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Realiza operaciones de inicio de sesion
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<object> Login(LoginModel login)
        {
            try
            {
                return await Task.Run(() =>
                {
                    TMREDUSUARIO usuario = UndTrabajo.MtroUsuarios.BuscarSencilloDefault(p => p.Email == login.Email);

                    if (usuario == null)
                    {
                        throw new NotFoundException("El usuario ingresado no se encuentra registrado");
                    }

                    string psw = GetSha512(login.Password);

                    if (psw != usuario.Password)
                    {
                        throw new BadRequestException("La contraseña es incorrecta");
                    }

                    CredencialesModel credenciales = new CredencialesModel();
                    credenciales.Email = usuario.Email;
                    credenciales.NombreUsuario = usuario.Nombre;
                    credenciales.Jwt = GeneraJWT(credenciales);

                    return credenciales;
                });
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex.InnerException ?? ex, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Obtiene usuario
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public async Task<object> ObtenerUsuarioPorId(int id)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var usuario = UndTrabajo.MtroUsuarios.BuscarSencilloDefault(p => p.UsuarioId == id);

                    if (usuario == null)
                    {
                        throw new NotFoundException("Usuario no encontrado");
                    }

                    UsuarioModel usuarioFinal = new UsuarioModel();
                    usuario.CopyPropertiesTo(usuarioFinal);
                    usuarioFinal.Edad = CalcularEdad(usuario.FechaNacimiento);
                    return usuarioFinal;
                });
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex.InnerException ?? ex, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Devuelve el listado de usuarios
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<object>> ObtenerUsuarios(FiltroUsuariosModel filtro, int numPagina, int longPagina)
        {
            try
            {
                return await Task.Run(() =>
                {
                    List<UsuarioModel> respuesta = new List<UsuarioModel>();
                    var listaUsuarios = UndTrabajo.MtroUsuarios.ObtenerTodos().OrderByDescending(u=>u.UsuarioId).AsQueryable();

                    if (!String.IsNullOrEmpty(filtro.Email))
                    {
                        listaUsuarios = listaUsuarios.Where(p => p.Email.Contains(filtro.Email));
                    }

                    if (!String.IsNullOrEmpty(filtro.Nombre))
                    {
                        listaUsuarios = listaUsuarios.Where(p => p.Nombre.Contains(filtro.Nombre));
                    }

                    if (!String.IsNullOrEmpty(filtro.ApellidoPaterno))
                    {
                        listaUsuarios = listaUsuarios.Where(p => p.ApellidoPaterno.Contains(filtro.ApellidoPaterno));
                    }

                    listaUsuarios = listaUsuarios.Skip((numPagina - 1) * longPagina).Take(longPagina);

                    listaUsuarios.ToList().ForEach(item =>
                    {
                        UsuarioModel temp = new UsuarioModel();
                        item.CopyPropertiesTo(temp);
                        temp.Edad = CalcularEdad(temp.FechaNacimiento);
                        respuesta.Add(temp);
                    });

                    return respuesta.ToList<object>();
                });
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex.InnerException ?? ex, HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Genera alta de la usuario
        /// </summary>
        /// <param name="mensaje"></param>
        public async Task<int> Guardar(UsuarioModel nvoUsuario)
        {
            try
            {
                return await Task.Run(() =>
                {
                    if (UndTrabajo.MtroUsuarios.AlgunElemento(p => p.Email == nvoUsuario.Email))
                    {
                        throw new BadRequestException("Ya existe un usuario con el correo ingresado");
                    }

                    TMREDUSUARIO usuario = new TMREDUSUARIO();
                    nvoUsuario.CopyPropertiesTo(usuario);
                    UndTrabajo.MtroUsuarios.Agregar(usuario);
                    UndTrabajo.GuardarCambios();
                    return usuario.UsuarioId;
                });
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Permite actualizar un usuario
        /// </summary>
        /// <param name="mensaje"></param>
        public async Task Actualizar(UsuarioModel actUsuario)
        {
            try
            {
                await Task.Run(() =>
                {
                    TMREDUSUARIO usuario = UndTrabajo.MtroUsuarios.BuscarSencilloDefault(f => f.UsuarioId == actUsuario.UsuarioId);
                    if (usuario == null)
                    {
                        throw new NotFoundException("El usuario no fue encontrado");
                    }

                    actUsuario.CopyPropertiesTo(usuario);
                    UndTrabajo.MtroUsuarios.Actualizar(usuario);
                    UndTrabajo.GuardarCambios();
                });
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Permite eliminar un usuario
        /// </summary>        
        /// <param name="mensaje"></param>
        public async Task Eliminar(int usuarioId) 
        {
            try
            {
                await Task.Run(() =>
                {
                    TMREDUSUARIO usuario = UndTrabajo.MtroUsuarios.BuscarSencilloDefault(f => f.UsuarioId == usuarioId);
                    if (usuario == null)
                    {
                        throw new NotFoundException("El usuario no fue encontrado");
                    }

                    UndTrabajo.MtroUsuarios.Eliminar(usuario);
                    UndTrabajo.GuardarCambios();
                });
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message, ex, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Genera token JWT
        /// </summary>
        /// <param name="Credenciales"></param>
        /// <returns></returns>
        private String GeneraJWT(CredencialesModel credenciales)
        {
            var configJwt = ObtenConfigJwt();
            var claims = new[] {
                new Claim(ClaimTypes.Name, credenciales.NombreUsuario),
                new Claim(ClaimTypes.Email, credenciales.Email)
            };
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configJwt.Key)), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configJwt.Issuer, configJwt.Audience, claims, expires: DateTime.Now.AddMinutes(90), signingCredentials: credentials);
            return JwtTokenHandler.WriteToken(token);
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Today;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }
        #endregion
    }
}
