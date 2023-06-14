using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Organization;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly ILogger<OrganizationService> logger;
        protected ServiceResult result;
        public OrganizationService(IOrganizationRepository organizationRepository, ILogger<OrganizationService> logger)
        {
            this.organizationRepository = organizationRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getOrganizations();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo las organizaciones";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getOrganizations(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo la organización";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyOrganization(OrganizationUpdateDto organizationUpdateDto)
        {
            try
            {
                // Field Validations
                if (organizationUpdateDto.Id == 0)
                {
                    this.result.Message = "Id de la organización a modificar es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                if (organizationUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                Organization organization = await this.organizationRepository.GetEntityByID(organizationUpdateDto.Id);


                if (organization == null)
                {
                    this.result.Message = "Esta organización no existe";
                    this.result.Success = false;
                    return this.result;
                }

                organization = organization.ConvertOrganizationUpdateDtoToOrganization(organizationUpdateDto);

                await this.organizationRepository.Update(organization);

                this.result.Message = "organización actualizada correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando la organización";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveOrganization(OrganizationAddDto organizationAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(organizationAddDto.Name))
                {
                    this.result.Message = "Nombre es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                Organization organization = organizationAddDto.ConvertOrganizationAddDtoToOrganization();


                await this.organizationRepository.Save(organization);

                this.result.Message = "Organización agregada correctamente";
                this.result.Data = organization.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando la organización";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.OrganizationGetModel>> getOrganizations(int? Id = null)
        {
            List<Models.OrganizationGetModel>? organizations = new List<Models.OrganizationGetModel>();
            try
            {
                organizations = (from organization in (await this.organizationRepository.GetAll())
                                 where organization.Id == Id || !Id.HasValue
                                 select organization.CreateOrganizationGetModel()).ToList();
            }
            catch (Exception ex)
            {
                organizations = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo las organizaciones", ex.ToString());
            }

            return organizations;
        }
    }
}
