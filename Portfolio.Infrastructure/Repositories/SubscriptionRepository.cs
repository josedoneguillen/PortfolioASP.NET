using System;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Infrastructure.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<SubscriptionRepository> _logger;
        public SubscriptionRepository(ApplicationDbContext context, ILogger<SubscriptionRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<Subscription>> GetAll()
        {
            List<Subscription> subscriptions = new List<Subscription>();

            try
            {
                subscriptions = await this._context.Subscriptions.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las subscripciones", ex.ToString());
            }

            return subscriptions;
        }

        public async override Task<Subscription> GetEntityByID(int Id)
        {
            Subscription subscription = new Subscription();

            try
            {
                subscription = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las subscripciones", ex.ToString());
            }

            return subscription;
        }

        public async override Task Save(Subscription entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la subscripción ", ex.ToString());
            }

        }

        public async override Task Update(Subscription entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la subscripción ", ex.ToString());
            }

        }
    }
}

