using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class ProjectCategoryRepository : BaseRepository<ProjectCategory>, IProjectCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectCategoryRepository> _logger;
        public ProjectCategoryRepository(ApplicationDbContext context, ILogger<ProjectCategoryRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

