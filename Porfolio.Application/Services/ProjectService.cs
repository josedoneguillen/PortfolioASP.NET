using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.Project;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly ILogger<ProjectService> logger;
        public ProjectService(IProjectRepository projectRepository, ILogger<ProjectService> logger)
        {
            this.projectRepository = projectRepository;
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

        Task<ServiceResult> IProjectService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<ProjectAddResponse> IProjectService.ModifyProject(ProjectUpdateDto projectUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<ProjectAddResponse> IProjectService.SaveProject(ProjectAddDto projectAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
