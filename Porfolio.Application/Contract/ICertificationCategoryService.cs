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
        Task<ServiceResult> SaveCertificationCategory(CertificationCategoryAddDto certificationCategoryAddDto);
        Task<ServiceResult> ModifyCertificationCategory(CertificationCategoryUpdateDto certificationCategoryUpdateDto);
    }
}
