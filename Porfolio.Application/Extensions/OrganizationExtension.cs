using System;
using Portfolio.Application.Dtos.Organization;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entities.Security;

namespace Portfolio.Application.Extensions
{
    public static class OrganizationExtension
    {
        public static Organization ConvertOrganizationAddDtoToOrganization(this OrganizationAddDto organizationAddDto)
        {
            return new Organization()
            {
                Name = organizationAddDto.Name,
                Description = organizationAddDto.Description,
                Website = organizationAddDto.Website,
                LogoUrl = organizationAddDto.LogoUrl,
                IdUserCreate = organizationAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = organizationAddDto.IsPublished,
                IsDeleted = false
            };
        }
        public static Organization ConvertOrganizationUpdateDtoToOrganization(this Organization organization, OrganizationUpdateDto organizationUpdateDto)
        {
            organization.Name = organizationUpdateDto.Name ?? organization.Name;
            organization.Description = organizationUpdateDto.Description ?? organization.Description;
            organization.Website = organizationUpdateDto.Website ?? organization.Website;
            organization.LogoUrl = organizationUpdateDto.LogoUrl != null ? organizationUpdateDto.LogoUrl : organization.LogoUrl;
            organization.IdUserModification = organizationUpdateDto.IdUser;
            organization.IdUserDelete = (organizationUpdateDto.IsDeleted == true) ? organizationUpdateDto.IdUser : 0;
            organization.IsPublished = organizationUpdateDto.IsPublished;
            organization.ModificationDate = DateTime.Now;
            organization.IsDeleted = organizationUpdateDto.IsDeleted ? organizationUpdateDto.IsDeleted : organization.IsDeleted;
            organization.DeletedDate = (organizationUpdateDto.IsDeleted == true) ? DateTime.Now : organization.DeletedDate;

            return organization;
        }
        public static OrganizationGetModel CreateOrganizationGetModel(this Organization organization)
        {
            return new Models.OrganizationGetModel()
            {
                Id = organization.Id,
                Name = organization.Name,
                Description = organization.Description,
                Website = organization.Website,
                LogoUrl = organization.LogoUrl,
                IsPublished = organization.IsPublished,
                IsDeleted = organization.IsDeleted
            };

        }
    }
}
