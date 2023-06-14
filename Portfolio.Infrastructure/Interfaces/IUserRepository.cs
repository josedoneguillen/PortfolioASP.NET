using Portfolio.Domain.Entities.Security;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Interfaces
{
    public interface IUserRepository : Domain.Repository.IBaseRepository<User>
    {
        Task<User> UserLogin(string email, string password);
    }
}
