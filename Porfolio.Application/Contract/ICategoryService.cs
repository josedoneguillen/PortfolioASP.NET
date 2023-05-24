using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Category;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface ICategoryService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveCategory(CategoryAddDto CategoryAddDto);
        Task<ServiceResult> ModifyCategory(CategoryUpdateDto CategoryUpdateDto);
    }
}
