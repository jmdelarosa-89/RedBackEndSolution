using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedBackEnd.Data.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        /// <summary>
        /// Agrega un registro nuevo
        /// </summary>
        /// <param name="entity"></param>
        void Agregar(TEntity entity);

        /// <summary>
        /// Actualiza un registro existente
        /// </summary>
        /// <param name="entity"></param>
        void Actualizar(TEntity entity);

        /// <summary>
        /// Elimina un registro
        /// </summary>
        /// <param name="entity"></param>
        void Eliminar(TEntity entity);

        /// <summary>
        /// Busca registros de acuerdo a un predicado
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Busca un solo elemento
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity BuscarSencilloDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtiene todos los registros
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> ObtenerTodos();

        /// <summary>
        /// Evalua si un elemento existe en la base de datos
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool AlgunElemento(Expression<Func<TEntity, bool>> predicate);
    }
}
