using RedBackEnd.Data.Interfaces;
using RedBackEnd.Domain.Tablas;

namespace RedBackEnd.Data.Repositories
{
    public class ITMREDUSUARIO_Repo : Repositorio<TMREDUSUARIO>, ITMREDUSUARIO
    {
        public ITMREDUSUARIO_Repo(RedDbContext db) : base(db) { }
    }
}
