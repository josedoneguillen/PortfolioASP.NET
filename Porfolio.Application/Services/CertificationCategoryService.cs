using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.CertificationCategory;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class CertificationCategoryService : ICertificationCategoryService
    {
        private readonly ICertificationCategoryRepository certificationCategoryRepository;
        private readonly ILogger<CertificationCategoryService> logger;
        public CertificationCategoryService(ICertificationCategoryRepository certificationCategoryRepository, ILogger<CertificationCategoryService> logger)
        {
            this.certificationCategoryRepository = certificationCategoryRepository;
            this.logger = logger;
        }
        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> ICertificationCategoryService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> SaveCertificationCategory(CertificationCategoryAddDto certificationCategoryAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ModifyCertificationCategory(CertificationCategoryUpdateDto certificationCategoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
