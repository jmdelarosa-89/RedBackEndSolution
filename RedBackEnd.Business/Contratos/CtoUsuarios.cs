using RedBackEnd.Business.Gestores;
using RedBackEnd.Business.Interfaces;

namespace RedBackEnd.Business.Contratos
{
    public class CtoUsuarios
    {
        public IGestorUsuarios GestionUsuarios { get; private set; }

        public CtoUsuarios()
        {
            GestionUsuarios = new GestorUsuarios();
        }
    }
}
