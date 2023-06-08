using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface ICertificationApiService
    {
        Task<CoreListResponse<CertificationModel>> GetCertifications();
        Task<CoreGetResponse<CertificationModel>> GetCertification(int Id);
        Task<CoreAddResponse> SaveCertification(CertificationSaveRequest certificationRequest);
        Task<CoreResponseModel> UpdateCertification(CertificationSaveRequest certificationRequest);
    }
}