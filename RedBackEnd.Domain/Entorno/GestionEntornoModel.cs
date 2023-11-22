namespace RedBackEnd.Domain.Entorno
{
    /// <summary>
    /// Modelo de la configuración de la app
    /// </summary>
    public class GestionEntornosModel
    {
        public GestionEntornosModel()
        {
            ConnectionStrings = new ConnectionsModel();
            Jwt = new JwtConfigModel();
        }

        public ConnectionsModel ConnectionStrings { get; set; }
        public JwtConfigModel Jwt { get; set; }
    }
}
