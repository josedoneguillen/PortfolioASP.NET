using Portfolio.Application.Core;
using Portfolio.Application.Dtos.ProjectCategory;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IProjectCategoryService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveProjectCategory(ProjectCategoryAddDto projectCategoryAddDto);
        Task<ServiceResult> ModifyProjectCategory(ProjectCategoryUpdateDto projectCategoryUpdateDto);
    }
}
