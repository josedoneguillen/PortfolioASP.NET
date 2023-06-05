using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<UserListResponse> GetUsers();
        Task<UserGetResponse> GetUser(int Id);
        Task<UserAddResponse> SaveUser(UserSaveRequest userRequest);
        Task<CoreResponseModel> UpdateUser(UserSaveRequest userRequest);
    }
}