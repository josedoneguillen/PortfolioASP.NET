using Portfolio.Application.Core;
using Portfolio.Application.Dtos.ProjectCategory;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IProjectCategoryService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ProjectCategoryAddResponse> SaveProjectCategory(ProjectCategoryAddDto projectCategoryAddDto);
        Task<ProjectCategoryAddResponse> ModifyProjectCategory(ProjectCategoryUpdateDto projectCategoryUpdateDto);
    }
}
