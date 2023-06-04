using System;
using System.Collections.Generic;
using Portfolio.Application.Dtos.Project;
using Portfolio.Application.Dtos.ProjectCategory;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Extensions
{
    public static class ProjectExtension
    {
        public static Project ConvertProjectAddDtoToProject(this ProjectAddDto projectAddDto)
        {
            return new Project()
            {
                Title = projectAddDto.Title,
                Slug = projectAddDto.Slug,
                Description = projectAddDto.Description,
                ImageUrl = projectAddDto.ImageUrl,
                GithubUrl = projectAddDto.GithubUrl,
                DemoUrl = projectAddDto.DemoUrl,
                OrganizationId = projectAddDto.OrganizationId,
                StartDate = projectAddDto.StartDate.Value,
                EndDate = projectAddDto.EndDate.Value,
                IsFeatured = projectAddDto.IsFeatured.Value,
                IsOngoing = projectAddDto.IsOngoing.Value,
                IdUserCreate = projectAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = projectAddDto.IsPublished.HasValue ? projectAddDto.IsPublished.Value : true,
                IsDeleted = false
            };
        }
        public static Project ConvertProjectUpdateDtoToProject(this Project project, ProjectUpdateDto projectUpdateDto)
        {
            project.Title = projectUpdateDto.Title ?? project.Title;
            project.Slug = projectUpdateDto.Slug ?? project.Slug;
            project.Description = projectUpdateDto.Description ?? project.Description;
            project.ImageUrl = projectUpdateDto.ImageUrl ?? project.ImageUrl;
            project.GithubUrl = projectUpdateDto.GithubUrl ?? project.GithubUrl;
            project.DemoUrl = projectUpdateDto.DemoUrl ?? project.DemoUrl;
            project.OrganizationId = projectUpdateDto.OrganizationId != 0 ? projectUpdateDto.OrganizationId : project.OrganizationId;
            project.StartDate = projectUpdateDto.StartDate ?? project.StartDate;
            project.EndDate = projectUpdateDto.EndDate ?? project.EndDate;
            project.IsFeatured = projectUpdateDto.IsFeatured.HasValue ? projectUpdateDto.IsFeatured.Value : project.IsFeatured;
            project.IsOngoing = projectUpdateDto.IsOngoing.HasValue ? projectUpdateDto.IsOngoing.Value :  project.IsOngoing;
            project.IdUserModification = projectUpdateDto.IdUser;
            project.IsPublished = projectUpdateDto.IsPublished.HasValue ? projectUpdateDto.IsPublished.Value : project.IsPublished;
            project.ModificationDate = DateTime.Now;
            project.IsDeleted = projectUpdateDto.IsDeleted.HasValue ? projectUpdateDto.IsDeleted.Value : project.IsDeleted;
            project.DeletedDate = (projectUpdateDto.IsDeleted.HasValue && projectUpdateDto.IsDeleted == true) ? DateTime.Now : project.DeletedDate;

            return project;
        }

        public static List<ProjectCategory> ConvertProjectCategoryAddDtoToProjectCategory(this List<ProjectCategoryAddDto> projectCategoryAddDto, int projectId, int idUserCreate)
        {
            List<ProjectCategory> projectCategories = new List<ProjectCategory>();

            foreach (var c in projectCategoryAddDto)
            {
                projectCategories.Add(
                    new ProjectCategory()
                    {
                        ProjectId = projectId,
                        CategoryId = c.CategoryId,
                        IdUserCreate = idUserCreate,
                        CreationDate = DateTime.Now,
                        IsPublished = true,
                        IsDeleted = false
                    }
                 );
            }

            return projectCategories;
        }

        public static ProjectGetModel CreateProjectGetModelFull(this Project project)
        {
            return new Models.ProjectGetModel()
            {
                Id = project.Id,
                Title = project.Title,
                Slug = project.Slug,
                Description = project.Description,
                ImageUrl = project.ImageUrl,
                GithubUrl = project.GithubUrl,
                DemoUrl = project.DemoUrl,
                OrganizationId = project.OrganizationId,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                IsFeatured = project.IsFeatured,
                IsOngoing = project.IsOngoing,
                Categories = new List<CategoryGetModel>()
            };

        }

        public static ProjectGetModel CreateProjectGetModel(this Project project, Organization organization)
        {
            return new Models.ProjectGetModel()
            {
                Id = project.Id,
                Title = project.Title,
                Slug = project.Slug,
                Description = project.Description,
                ImageUrl = project.ImageUrl,
                GithubUrl = project.GithubUrl,
                DemoUrl = project.DemoUrl,
                OrganizationId = project.OrganizationId,
                Organization = organization.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                IsFeatured = project.IsFeatured,
                IsOngoing = project.IsOngoing
            };

        }
    }
}
