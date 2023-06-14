using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Certification;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;
using Portfolio.Application.Dtos.CertificationCategory;
using Portfolio.Application.Models;

namespace Portfolio.Application.Services
{
    public class CertificationService : ICertificationService
    {
        private readonly ICertificationRepository certificationRepository;
        private readonly ICertificationCategoryRepository certificationCategoryRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IOrganizationRepository organizationRepository;
        private readonly ILogger<CertificationService> logger;
        protected ServiceResult result;
        public CertificationService(
            ICertificationRepository certificationRepository, 
            ICertificationCategoryRepository certificationCategoryRepository,
            ICategoryRepository categoryRepository,
            IOrganizationRepository organizationRepository,
            ILogger<CertificationService> logger
            )
        {
            this.certificationRepository = certificationRepository;
            this.certificationCategoryRepository = certificationCategoryRepository;
            this.categoryRepository = categoryRepository;
            this.organizationRepository = organizationRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {

                this.result.Data = (from certification in (await this.certificationRepository.GetAll())
                                  join organization in (await this.organizationRepository.GetAll()) on certification.OrganizationId equals organization.Id
                                  select certification.CreateCertificationGetModel(organization)
                             ).ToList();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo los certificados";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
           try
            {

                Certification certification = await this.certificationRepository.GetCertificationCategory(Id);

                CertificationGetModel cert = certification.CreateCertificationGetModelFull();

                // Get Organization
                cert.Organization = (from o in (await this.organizationRepository.GetAll())
                                     where o.Id == cert.OrganizationId
                                     select o.Name
                                     ).FirstOrDefault().ToString();

                // Get Categories
                cert.Categories = (from ca in (await this.categoryRepository.GetAll())
                              join cal in (certification.CertificationCategories) on ca.Id equals cal.CertificationId
                              select new Models.CategoryGetModel()
                              {
                                  Id = ca.Id,
                                  Name = ca.Name,
                                  Description = ca.Description
                              }).ToList();

                this.result.Data = cert;

           }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo el certificado";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyCertification(CertificationUpdateDto certificationUpdateDto)
        {
            try
            {
                // Field Validations
                if (certificationUpdateDto.Id == 0)
                {
                    this.result.Message = "Id del certificado a modificar es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                if (certificationUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificacion es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                Certification certification = await this.certificationRepository.GetEntityByID(certificationUpdateDto.Id);


                if (certification == null)
                {
                    this.result.Message = "Certificado no existe";
                    this.result.Success = false;
                    return this.result;
                }

                certification = certification.ConvertCertificationUpdateDtoToCertification(certificationUpdateDto);

                await this.certificationRepository.Update(certification);

                await this.AddCategories(certificationUpdateDto.Categories, certificationUpdateDto.Id, certificationUpdateDto.IdUser);

                this.result.Message = "Certificado actualizado correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando el certificado";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveCertification(CertificationAddDto certificationAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(certificationAddDto.Title))
                {
                    this.result.Message = "Titulo es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                if (certificationAddDto.OrganizationId <= 0)
                {
                    this.result.Message = "Id de la organización es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                if (string.IsNullOrEmpty(certificationAddDto.DateIssued.ToString()))
                {
                    this.result.Message = "Fecha es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                Certification certification = certificationAddDto.ConvertCertificationAddDtoToCertification();


                await this.certificationRepository.Save(certification);

                await this.AddCategories(certificationAddDto.Categories, certification.Id, certificationAddDto.IdUser);

                this.result.Message = "Certificado agregado correctamente";
                this.result.Data = certification.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando el certificado";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }
        private async Task AddCategories(List<CertificationCategoryAddDto> categories, int certificationId, int idUserCreate)
        {
            if (categories != null)
            {
                List<CertificationCategory> certificationCategories = new List<CertificationCategory>();
                certificationCategories = categories.ConvertCertificationCategoryAddDtoToCertificationCategory(certificationId, idUserCreate);

                this.certificationCategoryRepository.DeleteById(certificationId);
                await this.certificationCategoryRepository.Save(certificationCategories.ToArray());
            }
        }
    }
}
