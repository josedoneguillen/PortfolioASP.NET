using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

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
    }
}

