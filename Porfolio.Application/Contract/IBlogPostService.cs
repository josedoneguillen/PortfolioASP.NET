using Portfolio.Application.Core;
using Portfolio.Application.Dtos.BlogPost;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IBlogPostService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<BlogPostAddResponse> SaveBlogPost(BlogPostAddDto blogPostAddDto);
        Task<BlogPostAddResponse> ModifyBlogPost(BlogPostUpdateDto blogPostUpdateDto);
    }
}
