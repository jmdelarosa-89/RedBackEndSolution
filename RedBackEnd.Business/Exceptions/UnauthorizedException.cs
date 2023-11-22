using System.Net;

namespace RedBackEnd.Business.Exceptions
{
    /// <summary>
    /// Excepcion para una accion no autorizada
    /// </summary>
    public class UnauthorizedException : HttpRequestException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        public UnauthorizedException(string message) : base(message, new Exception(message), HttpStatusCode.Unauthorized)
        {
        }
    }
}
