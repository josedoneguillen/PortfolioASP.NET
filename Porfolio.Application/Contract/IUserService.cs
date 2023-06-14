using Portfolio.Application.Core;
using Portfolio.Application.Dtos.User;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IUserService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveUser(UserAddDto userAddDto);
        Task<ServiceResult> ModifyUser(UserUpdateDto userUpdateDto);

        Task<ServiceResult> UserLogin(UserLoginDto userLoginDto);
    }
}
