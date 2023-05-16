using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class ExperienceRepository : BaseRepository<Experience>, IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ExperienceRepository> _logger;
        public ExperienceRepository(ApplicationDbContext context, ILogger<ExperienceRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

