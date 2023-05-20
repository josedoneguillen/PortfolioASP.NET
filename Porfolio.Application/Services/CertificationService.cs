using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.Certification;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository certificationRepository;
        private readonly ILogger<CertificationService> logger;
        public CertificationService(ICertificationRepository certificationRepository, ILogger<CertificationService> logger)
        {
            this.certificationRepository = certificationRepository;
            this.logger = logger;
        }
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> ICertificationService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<CertificationAddResponse> ICertificationService.ModifyCertification(CertificationUpdateDto certificationUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<CertificationAddResponse> ICertificationService.SaveCertification(CertificationAddDto certificationAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
