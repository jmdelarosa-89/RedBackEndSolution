using System.Net;

namespace RedBackEnd.Business.Exceptions
{
    /// <summary>
    /// Excepcion para un elemento no encontrado
    /// </summary>
    public class NotFoundException : HttpRequestException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        public NotFoundException(String message) : base(message, new Exception(message), HttpStatusCode.NotFound)
        {
        }
    }
}
