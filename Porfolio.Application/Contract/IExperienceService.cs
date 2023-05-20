using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Experience;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IExperienceService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ExperienceAddResponse> SaveExperience(ExperienceAddDto experienceAddDto);
        Task<ExperienceAddResponse> ModifyExperience(ExperienceUpdateDto experienceUpdateDto);
    }
}
