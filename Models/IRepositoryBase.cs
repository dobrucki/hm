using System;
using System.Linq;
using System.Linq.Expressions;

namespace Models
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> FindAll();

        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}