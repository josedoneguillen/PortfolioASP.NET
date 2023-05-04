using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Portfolio.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> getEntityByID(int id);
        Task<IEnumerable<TEntity>> getAll();
        Task<TEntity> find(Expression<Func<TEntity, bool>> filter);
        Task save(TEntity entity);
        Task save(params TEntity[] entities);
        Task update(TEntity entity);
        Task update(params TEntity[] entities);
        Task<bool> exist(Expression<Func<TEntity, bool>> filter);
        Task saveChanges();
    }
}
