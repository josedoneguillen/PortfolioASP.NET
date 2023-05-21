using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Rol;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IRolService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveRol(RolAddDto rolAddDto);
        Task<ServiceResult> ModifyRol(RolUpdateDto rolUpdateDto);
    }
}
