using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Organization;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IOrganizationService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveOrganization(OrganizationAddDto organizationAddDto);
        Task<ServiceResult> ModifyOrganization(OrganizationUpdateDto organizationUpdateDto);
    }
}
