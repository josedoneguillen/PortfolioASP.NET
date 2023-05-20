using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Project;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IProjectService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ProjectAddResponse> SaveProject(ProjectAddDto projectAddDto);
        Task<ProjectAddResponse> ModifyProject(ProjectUpdateDto projectUpdateDto);
    }
}
