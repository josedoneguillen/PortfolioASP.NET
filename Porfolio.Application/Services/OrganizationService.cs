using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.Organization;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly ILogger<OrganizationService> logger;
        public OrganizationService(IOrganizationRepository organizationRepository, ILogger<OrganizationService> logger)
        {
            this.organizationRepository = organizationRepository;
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

        Task<ServiceResult> IOrganizationService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<OrganizationAddResponse> IOrganizationService.ModifyOrganization(OrganizationUpdateDto organizationUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<OrganizationAddResponse> IOrganizationService.SaveOrganization(OrganizationAddDto organizationAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
