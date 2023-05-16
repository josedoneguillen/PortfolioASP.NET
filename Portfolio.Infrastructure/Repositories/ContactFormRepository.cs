using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class ContactFormRepository : BaseRepository<ContactForm>, IContactFormRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContactFormRepository> _logger;
        public ContactFormRepository(ApplicationDbContext context, ILogger<ContactFormRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

