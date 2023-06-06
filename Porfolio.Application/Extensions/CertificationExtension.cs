using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Portfolio.Application.Dtos.Certification;
using Portfolio.Application.Dtos.CertificationCategory;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entities.Security;

namespace Portfolio.Application.Extensions
{
    public static class CertificationExtension
    {
        public static Certification ConvertCertificationAddDtoToCertification(this CertificationAddDto certificationAddDto)
        {
            return new Certification()
            {
                Title = certificationAddDto.Title,
                OrganizationId = certificationAddDto.OrganizationId.Value,
                DateIssued = certificationAddDto.DateIssued,
                CredentialId = certificationAddDto.CredentialId,
                CredentialUrl = certificationAddDto.CredentialUrl,
                Description = certificationAddDto.Description,
                ImageUrl = certificationAddDto.ImageUrl,
                FileUrl = certificationAddDto.FileUrl,
                IdUserCreate = certificationAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = certificationAddDto.IsPublished,
                IsDeleted = false
            };
        }
        public static Certification ConvertCertificationUpdateDtoToCertification(this Certification certification, CertificationUpdateDto certificationUpdateDto)
        {
            certification.Title = certificationUpdateDto.Title ?? certification.Title;
            certification.OrganizationId = certificationUpdateDto.OrganizationId.HasValue ? certificationUpdateDto.OrganizationId.Value  : certification.OrganizationId;
            certification.DateIssued = String.IsNullOrEmpty(certificationUpdateDto.DateIssued.ToString()) ? certificationUpdateDto.DateIssued : certification.DateIssued;
            certification.CredentialId = certificationUpdateDto.CredentialId ?? certification.CredentialId;
            certification.CredentialUrl = certificationUpdateDto.CredentialUrl ?? certification.CredentialUrl;
            certification.Description = certificationUpdateDto.Description ?? certification.Description;
            certification.ImageUrl = certificationUpdateDto.ImageUrl ?? certification.ImageUrl;
            certification.FileUrl = certificationUpdateDto.FileUrl ?? certification.FileUrl;
            certification.IdUserModification = certificationUpdateDto.IdUser;
            certification.IdUserDelete = (certificationUpdateDto.IsDeleted == true) ? certificationUpdateDto.IdUser : 0;
            certification.IsPublished = certificationUpdateDto.IsPublished;
            certification.ModificationDate = DateTime.Now;
            certification.IsDeleted = certificationUpdateDto.IsDeleted ? certificationUpdateDto.IsDeleted : certification.IsDeleted;
            certification.DeletedDate = (certificationUpdateDto.IsDeleted == true) ? DateTime.Now : certification.DeletedDate;

            return certification;
        }

        public static List<CertificationCategory> ConvertCertificationCategoryAddDtoToCertificationCategory(this List<CertificationCategoryAddDto> certificationCategoryAddDto, int certificationId, int idUserCreate)
        {
            List<CertificationCategory> certificationCategories = new List<CertificationCategory>();

            foreach (var c in certificationCategoryAddDto)
            {
                certificationCategories.Add(
                    new CertificationCategory()
                    { 
                        CertificationId = certificationId,
                        CategoryId = c.CategoryId,
                        IdUserCreate = idUserCreate,
                        CreationDate = DateTime.Now,
                        IsPublished = true,
                        IsDeleted = false
                    }
                 );
            }

            return certificationCategories;
        }
        public static CertificationGetModel CreateCertificationGetModelFull(this Certification certification)
        {
            return new Models.CertificationGetModel()
            {
                Id = certification.Id,
                Title = certification.Title,
                OrganizationId = certification.Id,
                DateIssued = certification.DateIssued,
                CredentialId = certification.CredentialId,
                CredentialUrl = certification.CredentialUrl,
                Description = certification.Description,
                ImageUrl = certification.ImageUrl,
                FileUrl = certification.FileUrl,
                Categories = new List<CategoryGetModel>(),
                IsPublished = certification.IsPublished,
                IsDeleted = certification.IsDeleted
            };

        }

        public static CertificationGetModel CreateCertificationGetModel(this Certification certification, Organization organization)
        {
            return new Models.CertificationGetModel()
            {
                Id = certification.Id,
                Title = certification.Title,
                OrganizationId = certification.Id,
                Organization = organization.Name,
                DateIssued = certification.DateIssued,
                CredentialId = certification.CredentialId,
                CredentialUrl = certification.CredentialUrl,
                Description = certification.Description,
                ImageUrl = certification.ImageUrl,
                FileUrl = certification.FileUrl,
                IsPublished = certification.IsPublished,
                IsDeleted = certification.IsDeleted
            };

        }
    }
}
