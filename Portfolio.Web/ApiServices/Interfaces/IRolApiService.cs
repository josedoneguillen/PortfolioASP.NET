using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IRolApiService
    {
        Task<CoreListResponse<RolModel>> GetRols();
        Task<CoreGetResponse<RolModel>> GetRol(int Id);
        Task<CoreAddResponse> SaveRol(RolSaveRequest rolRequest);
        Task<CoreResponseModel> UpdateRol(RolSaveRequest rolRequest);
    }
}