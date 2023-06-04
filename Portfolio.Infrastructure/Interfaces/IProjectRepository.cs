using Portfolio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Interfaces
{
    public interface IProjectRepository : Domain.Repository.IBaseRepository<Project>
    {
        Task<Project> GetProjectCategories(int projectId);
    }
}
