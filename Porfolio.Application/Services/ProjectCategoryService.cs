using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.ProjectCategory;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class ProjectCategoryService : IProjectCategoryService
    {
        private readonly IProjectCategoryRepository projectCategoryRepository;
        private readonly ILogger<ProjectCategoryService> logger;
        public ProjectCategoryService(IProjectCategoryRepository projectCategoryRepository, ILogger<ProjectCategoryService> logger)
        {
            this.projectCategoryRepository = projectCategoryRepository;
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

        Task<ServiceResult> IProjectCategoryService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<ProjectCategoryAddResponse> IProjectCategoryService.ModifyProjectCategory(ProjectCategoryUpdateDto projectCategoryUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<ProjectCategoryAddResponse> IProjectCategoryService.SaveProjectCategory(ProjectCategoryAddDto projectCategoryAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
