using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;

namespace Portfolio.Infrastructure.Repositories
{
    public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BlogPostRepository> _logger;
        public BlogPostRepository(ApplicationDbContext context, ILogger<BlogPostRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }
    }
}

