using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Rol;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IRolService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<RolAddResponse> SaveRol(RolAddDto rolAddDto);
        Task<RolAddResponse> ModifyRol(RolUpdateDto rolUpdateDto);
    }
}
