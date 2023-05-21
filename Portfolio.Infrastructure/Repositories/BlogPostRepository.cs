using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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

        public async override Task<IEnumerable<BlogPost>> GetAll()
        {
            List<BlogPost> blogPosts = new List<BlogPost>();

            try
            {
                blogPosts = await this._context.BlogPosts.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los post", ex.ToString());
            }

            return blogPosts;
        }

        public async override Task<BlogPost> GetEntityByID(int Id)
        {
            BlogPost blogPost = new BlogPost();

            try
            {
                blogPost = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los post", ex.ToString());
            }

            return blogPost;
        }

        public async override Task Save(BlogPost entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando el post ", ex.ToString());
            }

        }

        public async override Task Update(BlogPost entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando el post ", ex.ToString());
            }

        }
    }
}

