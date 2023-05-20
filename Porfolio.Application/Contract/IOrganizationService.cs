using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Organization;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IOrganizationService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<OrganizationAddResponse> SaveOrganization(OrganizationAddDto organizationAddDto);
        Task<OrganizationAddResponse> ModifyOrganization(OrganizationUpdateDto organizationUpdateDto);
    }
}
