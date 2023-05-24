using Portfolio.Application.Core;
using Portfolio.Application.Dtos.Certification;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface ICertificationService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveCertification(CertificationAddDto certificationAddDto);
        Task<ServiceResult> ModifyCertification(CertificationUpdateDto certificationUpdateDto);
    }
}
