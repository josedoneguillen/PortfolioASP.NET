using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities.Security;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RolRepository> _logger;
        public RolRepository(ApplicationDbContext context, ILogger<RolRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

