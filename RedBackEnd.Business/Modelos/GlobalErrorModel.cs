using Newtonsoft.Json;

namespace RedBackEnd.Business.Modelos
{
    /// <summary>
    /// Modelo general para manejar errores globales
    /// </summary>
    public class GlobalErrorModel
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_codigo"></param>
        public GlobalErrorModel(int _codigo)
        {
            this.Codigo = _codigo;
            this.Mensaje = "Ocurrió un error";
            this.Errores = new List<string>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_mensaje"></param>
        public GlobalErrorModel(int _codigo, string _mensaje)
        {
            this.Codigo = _codigo;
            this.Mensaje = _mensaje;
            this.Errores = new List<string>();
        }

        /// <summary>
        /// Agrega un mensaje de error
        /// </summary>
        /// <param name="_mensaje"></param>
        public void AgregaError(string _mensaje)
        {
            this.Errores.Add(_mensaje);
        }

        /// <summary>
        /// Agrega una lista de mensajes de error
        /// </summary>
        /// <param name="_mensajes"></param>
        public void AgregaErrores(List<string> _mensajes)
        {
            this.Errores.AddRange(_mensajes);
        }

        /// <summary>
        /// Genera una cadena a partir de la lista de errores
        /// </summary>
        /// <returns></returns>
        public string ErroresToString()
        {
            string errores = string.Empty;
            foreach (var error in Errores)
            {
                errores = string.Concat(errores, "|", error);
            }
            return errores;
        }

        /// <summary>
        /// Convierte el objeto a una cadena JSON
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
