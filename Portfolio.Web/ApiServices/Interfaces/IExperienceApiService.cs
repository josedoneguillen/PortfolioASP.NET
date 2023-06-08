using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IExperienceApiService
    {
        Task<CoreListResponse<ExperienceModel>> GetExperiences();
        Task<CoreGetResponse<ExperienceModel>> GetExperience(int Id);
        Task<CoreAddResponse> SaveExperience(ExperienceSaveRequest experienceRequest);
        Task<CoreResponseModel> UpdateExperience(ExperienceSaveRequest experienceRequest);
    }
}