using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Project;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IProjectService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveProject(ProjectAddDto projectAddDto);
        Task<ServiceResult> ModifyProject(ProjectUpdateDto projectUpdateDto);
    }
}
