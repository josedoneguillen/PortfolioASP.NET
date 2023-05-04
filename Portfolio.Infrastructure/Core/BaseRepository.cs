
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Infrastructure.Context;

namespace Portfolio.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : Domain.Repository.IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> myDbSet;
        public BaseRepository(ApplicationDbContext context) 
        {
            this.context = context;
            this.context.Set<TEntity>();
        }
        public async virtual Task<bool> exist(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.AnyAsync(filter);
        }

        public async virtual Task<TEntity> find(Expression<Func<TEntity, bool>> filter)
        {
            return await this.myDbSet.FindAsync(filter);
        }

        public async virtual Task<TEntity> getEntityByID(int id)
        {
            return await this.myDbSet.FindAsync(id);
        }

        public async virtual Task<IEnumerable<TEntity>> getAll()
        {
            return await this.myDbSet.ToListAsync();
        }

        public async virtual Task save(TEntity entity)
        {
            await this.myDbSet.AddAsync(entity);
        }

        public async virtual Task save(params TEntity[] entities)
        {
            await this.myDbSet.AddRangeAsync(entities);
        }

        public async virtual Task saveChanges()
        {
            await this.context.SaveChangesAsync();
        }

        public async virtual Task update(TEntity entity)
        {
            this.myDbSet.Update(entity);
        }

        public async virtual Task update(params TEntity[] entities)
        {
            this.myDbSet.UpdateRange(entities);
        }
    }
}
