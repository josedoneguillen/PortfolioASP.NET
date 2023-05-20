using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.BlogPost;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly ILogger<BlogPostService> logger;
        public BlogPostService(IBlogPostRepository blogPostRepository, ILogger<BlogPostService> logger)
        {
            this.blogPostRepository = blogPostRepository;
            this.logger = logger;
        }
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> IBlogPostService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<BlogPostAddResponse> IBlogPostService.ModifyBlogPost(BlogPostUpdateDto blogPostUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<BlogPostAddResponse> IBlogPostService.SaveBlogPost(BlogPostAddDto blogPostAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
