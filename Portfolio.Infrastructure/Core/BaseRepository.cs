using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Core;
using Portfolio.Infrastructure.Context;

namespace Portfolio.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : Domain.Repository.IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> myDbSet;
        public BaseRepository(ApplicationDbContext context) 
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();
        }
        public async virtual Task<bool> Exist(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.AnyAsync(filter);
        }

        public async virtual Task<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.FindAsync(filter);
        }

        public async virtual Task<TEntity> GetEntityByID(int id)
        {
            return await this.myDbSet.FindAsync(id);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll()
        {
            return await this.myDbSet.ToListAsync();
        }

        public async virtual Task Save(TEntity entity)
        {
            await this.myDbSet.AddAsync(entity);
        }

        public async virtual Task Save(params TEntity[] entities)
        {
            await this.myDbSet.AddRangeAsync(entities);
        }

        public async virtual Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }

        public async virtual Task Update(TEntity entity)
        {
            this.myDbSet.Update(entity);
        }

        public async virtual Task Update(params TEntity[] entities)
        {
            this.myDbSet.UpdateRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            this.myDbSet.Remove(entity);
        }

        public virtual void Delete(params TEntity[] entities)
        {
            this.myDbSet.RemoveRange(entities);
        }

        public virtual void DeleteById(int id)
        {
        }
    }
}
