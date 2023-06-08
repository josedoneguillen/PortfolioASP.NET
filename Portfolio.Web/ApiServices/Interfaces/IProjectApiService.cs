using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IProjectApiService
    {
        Task<CoreListResponse<ProjectModel>> GetProjects();
        Task<CoreGetResponse<ProjectModel>> GetProject(int Id);
        Task<CoreAddResponse> SaveProject(ProjectSaveRequest projectRequest);
        Task<CoreResponseModel> UpdateProject(ProjectSaveRequest projectRequest);
    }
}