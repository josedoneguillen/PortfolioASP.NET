using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Experience;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository experienceRepository;
        private readonly ILogger<ExperienceService> logger;
        protected ServiceResult result;
        public ExperienceService(IExperienceRepository experienceRepository, ILogger<ExperienceService> logger)
        {
            this.experienceRepository = experienceRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getExperiences();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo las experiencias";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getExperiences(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo la experiencia";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyExperience(ExperienceUpdateDto experienceUpdateDto)
        {
            try
            {
                // Field Validations
                if (experienceUpdateDto.Id == 0)
                {
                    this.result.Message = "Id de la experiencia a modificar es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                if (experienceUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                Experience experience = await this.experienceRepository.GetEntityByID(experienceUpdateDto.Id);


                if (experience == null)
                {
                    this.result.Message = "Esta experiencia no existe";
                    this.result.Success = false;
                    return this.result;
                }

                experience = experience.ConvertExperienceUpdateDtoToExperience(experienceUpdateDto);

                await this.experienceRepository.Update(experience);

                this.result.Message = "experiencia actualizada correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando la experiencia";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveExperience(ExperienceAddDto experienceAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(experienceAddDto.Title))
                {
                    this.result.Message = "Titulo es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                Experience experience = experienceAddDto.ConvertExperienceAddDtoToExperience();


                await this.experienceRepository.Save(experience);

                this.result.Message = "Experiencia agregada correctamente";
                this.result.Data = experience.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando la experiencia";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.ExperienceGetModel>> getExperiences(int? Id = null)
        {
            List<Models.ExperienceGetModel>? experiences = new List<Models.ExperienceGetModel>();
            try
            {
                experiences = (from experience in (await this.experienceRepository.GetAll())
                                 where experience.Id == Id || !Id.HasValue
                                 select experience.CreateExperienceGetModel()).ToList();
            }
            catch (Exception ex)
            {
                experiences = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo las experiencias", ex.ToString());
            }

            return experiences;
        }
    }
}
