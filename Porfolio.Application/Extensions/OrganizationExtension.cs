using System;
using Portfolio.Application.Dtos.Organization;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

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
                IsPublished = organizationAddDto.IsPublished.HasValue ? organizationAddDto.IsPublished.Value : true,
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
            organization.IsPublished = organizationUpdateDto.IsPublished.HasValue ? organizationUpdateDto.IsPublished.Value : organization.IsPublished;
            organization.ModificationDate = DateTime.Now;
            organization.IsDeleted = organizationUpdateDto.IsDeleted.HasValue ? organizationUpdateDto.IsDeleted.Value : organization.IsDeleted;
            organization.DeletedDate = (organizationUpdateDto.IsDeleted.HasValue && organizationUpdateDto.IsDeleted == true) ? DateTime.Now : organization.DeletedDate;

            return organization;
        }
        public static OrganizationGetModel CreateOrganizationGetModel(this Organization organization)
        {
            return new Models.OrganizationGetModel()
            {
                Name = organization.Name,
                Description = organization.Description,
                Website = organization.Website,
                LogoUrl = organization.LogoUrl,
            };

        }
    }
}
