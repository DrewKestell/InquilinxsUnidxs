using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Context
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeExpressions); // FIXME: there's a better way to handle .Include()
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}