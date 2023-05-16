using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrganizationRepository> _logger;
        public OrganizationRepository(ApplicationDbContext context, ILogger<OrganizationRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

