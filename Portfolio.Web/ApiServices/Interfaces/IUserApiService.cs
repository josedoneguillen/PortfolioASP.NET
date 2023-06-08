using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<CoreListResponse<UserModel>> GetUsers();
        Task<CoreGetResponse<UserModel>> GetUser(int Id);
        Task<CoreAddResponse> SaveUser(UserSaveRequest userRequest);
        Task<CoreResponseModel> UpdateUser(UserSaveRequest userRequest);
    }
}