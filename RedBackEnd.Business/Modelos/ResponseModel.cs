namespace RedBackEnd.Business.Modelos
{
    /// <summary>
    /// Modelo general de respuesta
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Codigo HttpStatus
        /// </summary>
        public int Codigo { get; set; }

        /// <summary>
        /// Mensaje
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Objeto de datos
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// Constructor codigo y mensaje
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_mensaje"></param>
        public ResponseModel(int _codigo, string _mensaje)
        {
            Codigo = _codigo;
            Mensaje = _mensaje;
            Data = _mensaje;
        }

        /// <summary>
        /// Constructor tres elementos
        /// </summary>
        /// <param name="_codigo"></param>
        /// <param name="_mensaje"></param>
        /// <param name="_data"></param>
        public ResponseModel(int _codigo, string _mensaje, object _data)
        {
            Codigo = _codigo;
            Mensaje = _mensaje;
            Data = _data;
        }
    }
}
