using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class CertificationRepository : BaseRepository<Certification>, ICertificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CertificationRepository> _logger;
        public CertificationRepository(ApplicationDbContext context, ILogger<CertificationRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

