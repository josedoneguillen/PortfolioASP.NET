using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.Experience;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly ILogger<ExperienceService> logger;
        public ExperienceService(IExperienceRepository experienceRepository, ILogger<ExperienceService> logger)
        {
            this.experienceRepository = experienceRepository;
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

        Task<ServiceResult> IExperienceService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<ExperienceAddResponse> IExperienceService.ModifyExperience(ExperienceUpdateDto experienceUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<ExperienceAddResponse> IExperienceService.SaveExperience(ExperienceAddDto experienceAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
