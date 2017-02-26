using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Context
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(ApplicationContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Get() =>
            DbSet.AsQueryable();

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate) =>
            DbSet.Where(predicate);

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate) =>
            DbSet.FirstOrDefault(predicate);

        public TEntity Single(Expression<Func<TEntity, bool>> predicate) =>
            DbSet.Single(predicate);

        public void Add(TEntity entity) =>
            DbSet.Add(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) =>
            DbSet.RemoveRange(entities);

        public void Remove(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
                DbSet.Attach(entityToDelete);
            DbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeExpressions) =>
            includeExpressions.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                (DbSet, (current, expression) => current.Include(expression));
    }
}