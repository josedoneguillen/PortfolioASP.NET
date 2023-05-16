using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class CertificationCategoryRepository : BaseRepository<CertificationCategory>, ICertificationCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CertificationCategoryRepository> _logger;
        public CertificationCategoryRepository(ApplicationDbContext context, ILogger<CertificationCategoryRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

