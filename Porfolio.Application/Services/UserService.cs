using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.User;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities.Security;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRolRepository rolRepository;
        private readonly ILogger<UserService> logger;
        protected ServiceResult result;
        public UserService(IUserRepository userRepository, IRolRepository rolRepository, ILogger<UserService> logger)
        { 
            this.userRepository = userRepository;
            this.rolRepository = rolRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getUsers();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo los usuarios";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getUsers(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo el usuario";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyUser(UserUpdateDto userUpdateDto)
        {
            try
            {
                // Field Validations
                if (userUpdateDto.Id == 0)
                {
                    this.result.Message = "Id del usuario a modificar es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (userUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificacion es requerido";
                    this.result.Success = false;
                    return result;
                }

                User user = await this.userRepository.GetEntityByID(userUpdateDto.Id);

               
                if (user == null)
                {
                    this.result.Message = "Usuario no existe";
                    this.result.Success = false;
                    return result;
                }

                user = user.ConvertUserUpdateDtoToUser(userUpdateDto);

                await this.userRepository.Update(user);

                this.result.Message = "Usuario actualizado correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando el usuario";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveUser(UserAddDto userAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(userAddDto.FirstName))
                {
                    this.result.Message = "Nombre es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(userAddDto.LastName))
                {
                    this.result.Message = "Apellido es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(userAddDto.Email))
                {
                    this.result.Message = "Email es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (string.IsNullOrEmpty(userAddDto.Password))
                {
                    this.result.Message = "Clave es requerida";
                    this.result.Success = false;
                    return result;
                }

                User user = userAddDto.ConvertUserAddDtoToUser();


                await this.userRepository.Save(user);

                this.result.Message = "Usuario agregado correctamente";
                this.result.Data = user.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando el usuario";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.UserGetModel>> getUsers(int? Id = null)
        {
            List<Models.UserGetModel>? users = new List<Models.UserGetModel>();
            try
            {
                users = (from user in (await this.userRepository.GetAll())
                             join rol in (await this.rolRepository.GetAll()) on user.RolId equals rol.Id
                             where user.Id == Id || !Id.HasValue
                             select user.CreateUserGetModel(rol)).ToList();
            }
            catch (Exception ex)
            {
                users = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo los usuarios", ex.ToString());
            }

            return users;
        }
    }
}
