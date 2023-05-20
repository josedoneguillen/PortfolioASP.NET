using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Certification;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface ICertificationService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<CertificationAddResponse> SaveCertification(CertificationAddDto certificationAddDto);
        Task<CertificationAddResponse> ModifyCertification(CertificationUpdateDto certificationUpdateDto);
    }
}
