using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Rol;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities.Security;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository rolRepository;
        private readonly ILogger<RolService> logger;
        protected ServiceResult result;
        public RolService(IRolRepository rolRepository, ILogger<RolService> logger)
        {
            this.rolRepository = rolRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getRols();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo los roles";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getRols(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo el rol";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyRol(RolUpdateDto rolUpdateDto)
        {
            try
            {
                // Field Validations
                if (rolUpdateDto.Id == 0)
                {
                    this.result.Message = "Id del rol a modificar es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (rolUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return result;
                }

                Rol rol = await this.rolRepository.GetEntityByID(rolUpdateDto.Id);


                if (rol == null)
                {
                    this.result.Message = "Rol no existe";
                    this.result.Success = false;
                    return result;
                }

                rol = rol.ConvertRolUpdateDtoToRol(rolUpdateDto);

                await this.rolRepository.Update(rol);

                this.result.Message = "Rol actualizado correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando el rol";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveRol(RolAddDto rolAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(rolAddDto.Name))
                {
                    this.result.Message = "Nombre es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(rolAddDto.Description))
                {
                    this.result.Message = "Descripción es requerido";
                    this.result.Success = false;
                    return result;
                }

                Rol rol = rolAddDto.ConvertRolAddDtoToRol();


                await this.rolRepository.Save(rol);

                this.result.Message = "Rol agregado correctamente";
                this.result.Data = rol.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando el rol";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.RolGetModel>> getRols(int? Id = null)
        {
            List<Models.RolGetModel>? rols = new List<Models.RolGetModel>();
            try
            {
                rols = (from rol in (await this.rolRepository.GetAll())
                         where rol.Id == Id || !Id.HasValue
                         select rol.CreateRolGetModel()).ToList();
            }
            catch (Exception ex)
            {
                rols = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los roles", ex.ToString());
            }

            return rols;
        }
    }
}
