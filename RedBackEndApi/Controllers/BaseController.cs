using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Net;
using RedBackEnd.Business.Modelos;

namespace RedBackEndApi.Controllers
{
    /// <summary>
    /// Controller que contiene funciones generales
    /// </summary>
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Genera una respuesta personalizada de acuerdo al tipo de excepción recibido
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected ObjectResult GeneraObjectResult(HttpRequestException ex)
        {
            int statusCode = (int)(ex.StatusCode ?? HttpStatusCode.InternalServerError);
            ObjectResult obj = new(new ResponseModel(statusCode, ex.Message))
            {
                StatusCode = statusCode
            };
            obj.ContentTypes.Add(MediaTypeNames.Application.Json);
            return obj;
        }
    }
}
