using Microsoft.EntityFrameworkCore;
using RedBackEnd.Data.Auxiliares;
using RedBackEnd.Domain.Tablas;

namespace RedBackEnd.Data
{
    /// <summary>
    /// Contexto general de la base de datos
    /// </summary>
    public partial class RedDbContext : DbContext
    {
        #region Constructor
        public RedDbContext() : base()
        {
        }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GestionEntorno.CadenaConexion);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se define el campo identity
            modelBuilder.Entity<TMREDUSUARIO>()
                .Property(p => p.UsuarioId)
                .UseIdentityColumn();

            //Se define la llave primaria
            modelBuilder.Entity<TMREDUSUARIO>()
                .HasKey(p => new
                {
                    p.UsuarioId
                });
        }

        /// <summary>
        /// Maestro de usuarios
        /// </summary>
        public DbSet<TMREDUSUARIO> TMREDUSUARIO { get; set; }

    }
}