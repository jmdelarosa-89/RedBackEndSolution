using Newtonsoft.Json;
using RedBackEnd.Data.Interfaces;
using RedBackEnd.Data.Repositories;
using RedBackEnd.Domain.Entorno;
using System.Text;

namespace RedBackEnd.Business.Gestores
{
    public class GestorGeneral
    {
        /// <summary>
        /// Contiene los parametros de comunicacion con la 
        /// capa de datos, es de tipo restrictivo a solo 
        /// uso dentro de esta capa
        /// </summary>
        protected readonly IUnidadDeTrabajo UndTrabajo;

        public GestorGeneral()
        {
            try
            {
                UndTrabajo = new UnidadDeTrabajo();
            }
            catch (Exception ex)
            {
                throw new Exception(@"BL\GeneralTools\" + ex.Message, ex);
            }
        }

        /// <summary>
        /// Permite la conversión de cadenas a cadenas codificadas en SHA512
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static string GetSha512(String value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hashedInputBytes = System.Security.Cryptography.SHA512.HashData(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);

            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }

        /// <summary>
        /// Obtiene configuracion del JWT
        /// </summary>
        /// <returns></returns>
        #region ObtenConfigJwt
        protected static JwtConfigModel ObtenConfigJwt()
        {
            string[] path1 = Directory.GetCurrentDirectory().Split(new string[] { ".Bussiness" }, StringSplitOptions.None);
            string path = Path.Combine(path1[0], "appsettings.json");
            string JsonFile = File.ReadAllText(path, Encoding.UTF8);
            GestionEntornosModel entorno = JsonConvert.DeserializeObject<GestionEntornosModel>(JsonFile);
            return entorno.Jwt;
        }
        #endregion
    }


}
