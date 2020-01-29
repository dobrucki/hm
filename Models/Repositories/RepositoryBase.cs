using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Models.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IQueryable<TEntity> FindAll()
        {
            return _dataContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dataContext.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public void Create(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
        }
    }
}