using System.Net;

namespace RedBackEnd.Business.Exceptions
{
    /// <summary>
    /// Excepcion para una solicitud mal formada
    /// </summary>
    public class BadRequestException : HttpRequestException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        public BadRequestException(String message) : base(message, new Exception(message), HttpStatusCode.BadRequest)
        {
        }
    }
}
