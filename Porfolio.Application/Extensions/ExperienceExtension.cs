using System;
using Portfolio.Application.Dtos.Experience;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Extensions
{
    public static class ExperienceExtension
    {
        public static Experience ConvertExperienceAddDtoToExperience(this ExperienceAddDto experienceAddDto)
        {
            return new Experience()
            {
                Title = experienceAddDto.Title,
                Company = experienceAddDto.Company,
                Description = experienceAddDto.Description,
                OrganizationId = experienceAddDto.OrganizationId,
                StartDate = experienceAddDto.StartDate,
                EndDate = experienceAddDto.EndDate,
                IdUserCreate = experienceAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = true,
                IsDeleted = false
            };
        }
        public static Experience ConvertExperienceUpdateDtoToExperience(this Experience experience, ExperienceUpdateDto experienceUpdateDto)
        {
            experience.Title = experienceUpdateDto.Title ?? experience.Title;
            experience.Description = experienceUpdateDto.Description ?? experience.Description;
            experience.Company = experienceUpdateDto.Company ?? experience.Company;
            experience.OrganizationId = experienceUpdateDto.OrganizationId != null ? experienceUpdateDto.OrganizationId : experience.OrganizationId;
            experience.StartDate = experienceUpdateDto.StartDate != null ? experienceUpdateDto.StartDate  : experience.StartDate;
            experience.EndDate = experienceUpdateDto.EndDate != null ? experienceUpdateDto.StartDate : experience.EndDate;
            experience.IdUserModification = experienceUpdateDto.IdUser;
            experience.IsPublished = experienceUpdateDto.IsPublished.HasValue ? experienceUpdateDto.IsPublished.Value : experience.IsPublished;
            experience.ModificationDate = DateTime.Now;
            experience.IsDeleted = experienceUpdateDto.IsDeleted.HasValue ? experienceUpdateDto.IsDeleted.Value : experience.IsDeleted;
            experience.DeletedDate = (experienceUpdateDto.IsDeleted.HasValue && experienceUpdateDto.IsDeleted == true) ? DateTime.Now : experience.DeletedDate;

            return experience;
        }
        public static ExperienceGetModel CreateExperienceGetModel(this Experience experience)
        {
            return new Models.ExperienceGetModel()
            {
                Title = experience.Title,
                Description = experience.Description,
                Company = experience.Company,
                OrganizationId = experience.OrganizationId,
                StartDate = experience.StartDate,
                EndDate = experience.EndDate
        };

        }
    }
}
