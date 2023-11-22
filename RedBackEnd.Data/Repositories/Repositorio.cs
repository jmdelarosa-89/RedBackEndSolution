using Microsoft.EntityFrameworkCore;
using RedBackEnd.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Data.Repositories
{

    public class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        #region Propiedades
        /// <summary>
        /// Contexto de la base de datos
        /// </summary>
        protected readonly DbContext db;

        #endregion

        #region Constructor
        /// <summary>
        /// Inicializacion del constructor
        /// </summary>
        /// <param name="context"></param>
        public Repositorio(DbContext context)
        {
            this.db = context;
        }
        #endregion

        #region Funciones

        /// <summary>
        /// Agrega un registro nuevo
        /// </summary>
        /// <param name="entity"></param>
        public void Agregar(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Actualiza un registro existente
        /// </summary>
        /// <param name="entity"></param>
        public void Actualizar(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="entity"></param>
        public void Eliminar(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Busca registros de acuerdo a un predicado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate).AsQueryable();
        }

        /// <summary>
        /// Busca un solo elemento
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity BuscarSencilloDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> ObtenerTodos()
        {
            return db.Set<TEntity>().AsQueryable();
        }

        /// <summary>
        /// Evalua si un elemento existe en la base de datos
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool AlgunElemento(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Any(predicate);
        }
        #endregion
    }
}
