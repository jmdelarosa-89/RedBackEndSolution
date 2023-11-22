using Microsoft.EntityFrameworkCore;
using RedBackEnd.Data.Interfaces;
using RedBackEnd.Domain;
using RedBackEnd.Domain.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Data.Repositories
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        #region Propiedades
        /// <summary>
        /// Acceso al contexto de Datos
        /// </summary>
        private readonly RedDbContext db;

        #endregion

        #region Tablas
        /// <summary>
        /// Interface: Maestro de usuarios
        /// </summary>
        public ITMREDUSUARIO MtroUsuarios { get; private set; }
        #endregion

        #region Constructor
        public UnidadDeTrabajo()
        {
            try
            {
                db = new RedDbContext();
                MtroUsuarios = new ITMREDUSUARIO_Repo(db);
                db.Database.Migrate();

                if (!db.TMREDUSUARIO.Any())
                {
                    var usuariosIniciales = new List<TMREDUSUARIO>();
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09281", Email = "a09281@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1991, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09282", Email = "a09282@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1992, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09283", Email = "a09283@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1993, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09284", Email = "a09284@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1994, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09285", Email = "a09285@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1995, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09286", Email = "a09286@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1996, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09287", Email = "a09287@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1997, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09288", Email = "a09288@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1998, 1, 1) });
                    usuariosIniciales.Add(new TMREDUSUARIO { Nombre = "Tester", ApellidoPaterno = "A-09289", Email = "a09289@tester.com", Password = "F939D35EE4F26B2A9A169B35E5995F8856407F5F0C16CE2713045DE87A1DE032E25CE8A49C5309736D4AB68E5E750207893516005B6CA9E65D72F88556737C96", FechaNacimiento = new DateTime(1999, 1, 1) });

                    db.TMREDUSUARIO.AddRange(usuariosIniciales);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@"DAL\UnidadTrabajo\" + ex.Message, ex);
            }
        }
        #endregion

        #region Metodos de Contexto
        /// <summary>
        /// Libera la conexión con la base de datos
        /// </summary>
        public void Dispose()
        {
            db.Dispose();
        }

        /// <summary>
        /// Función que guarda los cambios en la base de datos de forma asincrona
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void GuardarCambios()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(@"DAL\UnidadTrabajo\" + ex.Message, ex);
            }
        }

        #endregion
    }
}
