using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IBlogPostApiService
    {
        Task<CoreListResponse<BlogPostModel>> GetBlogPosts();
        Task<CoreGetResponse<BlogPostModel>> GetBlogPost(int Id);
        Task<CoreAddResponse> SaveBlogPost(BlogPostSaveRequest blogPostRequest);
        Task<CoreResponseModel> UpdateBlogPost(BlogPostSaveRequest blogPostRequest);
    }
}