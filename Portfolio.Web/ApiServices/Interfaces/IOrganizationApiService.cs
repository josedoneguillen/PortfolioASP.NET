using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IOrganizationApiService
    {
        Task<CoreListResponse<OrganizationModel>> GetOrganizations();
        Task<CoreGetResponse<OrganizationModel>> GetOrganization(int Id);
        Task<CoreAddResponse> SaveOrganization(OrganizationSaveRequest organizationRequest);
        Task<CoreResponseModel> UpdateOrganization(OrganizationSaveRequest organizationRequest);
    }
}