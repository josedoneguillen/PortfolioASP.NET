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
            this.projectCategoryRepository = projectCategoryRepository ?? throw new ArgumentNullException(nameof(projectCategoryRepository));
            this.logger = logger;
        }
        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> IProjectCategoryService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }
        public Task<ServiceResult> SaveProjectCategory(ProjectCategoryAddDto projectCategoryAddDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> ModifyProjectCategory(ProjectCategoryUpdateDto projectCategoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
