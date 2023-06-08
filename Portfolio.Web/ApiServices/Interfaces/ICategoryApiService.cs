using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<CoreListResponse<CategoryModel>> GetCategorys();
        Task<CoreGetResponse<CategoryModel>> GetCategory(int Id);
        Task<CoreAddResponse> SaveCategory(CategorySaveRequest categoryRequest);
        Task<CoreResponseModel> UpdateCategory(CategorySaveRequest categoryRequest);
    }
}