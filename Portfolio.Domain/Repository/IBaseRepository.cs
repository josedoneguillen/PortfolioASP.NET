using Portfolio.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Portfolio.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetEntityByID(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> filter);
        Task Save(TEntity entity);
        Task Save(params TEntity[] entities);
        Task Update(TEntity entity);
        Task Update(params TEntity[] entities);
        void Delete(TEntity entity);
        void Delete(params TEntity[] entities);
        void DeleteById(int id);
        Task<bool> Exist(Expression<Func<TEntity, bool>> filter);
        Task SaveChanges();
    }
}
