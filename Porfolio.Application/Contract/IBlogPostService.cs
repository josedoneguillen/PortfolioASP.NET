using Portfolio.Application.Core;
using Portfolio.Application.Dtos.BlogPost;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IBlogPostService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveBlogPost(BlogPostAddDto blogPostAddDto);
        Task<ServiceResult> ModifyBlogPost(BlogPostUpdateDto blogPostUpdateDto);
    }
}
