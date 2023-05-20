using Portfolio.Application.Core;
using Portfolio.Application.Dtos.CertificationCategory;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface ICertificationCategoryService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<CertificationCategoryAddResponse> SaveCertificationCategory(CertificationCategoryAddDto certificationCategoryAddDto);
        Task<CertificationCategoryAddResponse> ModifyCertificationCategory(CertificationCategoryUpdateDto certificationCategoryUpdateDto);
    }
}
