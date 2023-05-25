using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Project;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;
using Portfolio.Application.Dtos.ProjectCategory;

namespace Portfolio.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IProjectCategoryRepository projectCategoryRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IOrganizationRepository organizationRepository;
        private readonly ILogger<ProjectService> logger;
        protected ServiceResult result;
        public ProjectService(
            IProjectRepository projectRepository,
            IProjectCategoryRepository projectCategoryRepository,
            ICategoryRepository categoryRepository,
            IOrganizationRepository organizationRepository,
            ILogger<ProjectService> logger
            )
        {
            this.projectRepository = projectRepository;
            this.projectCategoryRepository = projectCategoryRepository;
            this.categoryRepository = categoryRepository;
            this.organizationRepository = organizationRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getProjects();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo los proyectos";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getProjects(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo el proyecto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyProject(ProjectUpdateDto projectUpdateDto)
        {
            try
            {
                // Field Validations
                if (projectUpdateDto.Id == 0)
                {
                    this.result.Message = "Id del proyecto a modificar es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (projectUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificacion es requerido";
                    this.result.Success = false;
                    return result;
                }

                Project project = await this.projectRepository.GetEntityByID(projectUpdateDto.Id);


                if (project == null)
                {
                    this.result.Message = "Proyecto no existe";
                    this.result.Success = false;
                    return result;
                }

                project = project.ConvertProjectUpdateDtoToProject(projectUpdateDto);

                await this.projectRepository.Update(project);

                await this.AddCategories(projectUpdateDto.Categories, projectUpdateDto.Id, projectUpdateDto.IdUser);

                this.result.Message = "Proyecto actualizado correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando el proyecto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveProject(ProjectAddDto projectAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(projectAddDto.Title))
                {
                    this.result.Message = "Titulo es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (projectAddDto.OrganizationId <= 0)
                {
                    this.result.Message = "Id de la organización es requerido";
                    this.result.Success = false;
                    return result;
                }


                Project project = projectAddDto.ConvertProjectAddDtoToProject();


                await this.projectRepository.Save(project);

                await this.AddCategories(projectAddDto.Categories, project.Id, projectAddDto.IdUser);

                this.result.Message = "Proyecto agregado correctamente";
                this.result.Data = project.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando el proyecto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.ProjectGetModel>> getProjects(int? Id = null)
        {
            List<Models.ProjectGetModel>? projects = new List<Models.ProjectGetModel>();
            try
            {

                projects = (from project in (await this.projectRepository.GetAll())
                            join organization in (await this.organizationRepository.GetAll()) on project.OrganizationId equals organization.Id
                            where project.Id == Id || !Id.HasValue
                            select project.CreateProjectGetModel(organization)).ToList();


                foreach (Models.ProjectGetModel c in projects)
                {
                    List<Models.CategoryGetModel> categories = await this.getCategories(c.Id);
                    c.Categories.AddRange(categories);
                }
            }
            catch (Exception ex)
            {
                projects = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los proyectos", ex.ToString());
            }

            return projects;
        }

        private async Task<List<Models.CategoryGetModel>> getCategories(int projectId)
        {
            List<Models.CategoryGetModel>? categories = new List<Models.CategoryGetModel>();
            try
            {

                categories = (from projectCategory in (await this.projectCategoryRepository.GetAll())
                              join category in (await this.categoryRepository.GetAll()) on projectCategory.CategoryId equals category.Id
                              where projectCategory.ProjectId == projectId
                              select new Models.CategoryGetModel
                              {
                                  Id = category.Id,
                                  Name = category.Name,
                                  Description = category.Description
                              }

                         ).ToList();
            }
            catch (Exception ex)
            {
                categories = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo las categorias de los proyectos", ex.ToString());
            }

            return categories;
        }

        private async Task AddCategories(List<ProjectCategoryAddDto> categories, int projectId, int idUserCreate)
        {
            if (categories != null)
            {
                List<ProjectCategory> projectCategories = new List<ProjectCategory>();
                projectCategories = categories.ConvertProjectCategoryAddDtoToProjectCategory(projectId, idUserCreate);

                this.projectCategoryRepository.DeleteById(projectId);
                await this.projectCategoryRepository.Save(projectCategories.ToArray());
            }
        }
    }
}
