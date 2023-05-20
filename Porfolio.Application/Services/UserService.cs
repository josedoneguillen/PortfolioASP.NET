using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.User;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using Portfolio.Domain.Entities.Security;

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
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                var query = (from user in (await this.userRepository.GetAll())
                             join rol in (await this.rolRepository.GetAll()) on user.RolId equals rol.Id
                             select new Models.UserGetModel()
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 Description = user.Description,
                                 Image = user.Image,
                                 Position = user.Position,
                                 Rol = rol.Name,
                                 RolId = user.RolId
                             }).ToList();

                this.result.Data = query;
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
                var query = (from user in (await this.userRepository.GetAll())
                             join rol in (await this.rolRepository.GetAll()) on user.RolId equals rol.Id
                             where user.Id == Id
                             select new Models.UserGetModel()
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PhoneNumber = user.PhoneNumber,
                                 Description = user.Description,
                                 Image = user.Image,
                                 Position = user.Position,
                                 Rol = rol.Name,
                                 RolId = user.RolId
                             }).FirstOrDefault();

                this.result.Data = query;
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

                user.FirstName = userUpdateDto.FirstName ?? user.FirstName;
                user.LastName = userUpdateDto.LastName ?? user.LastName;
                user.Email = userUpdateDto.Email ?? user.Email;
                user.PhoneNumber = userUpdateDto.PhoneNumber ?? user.PhoneNumber;
                user.Password = userUpdateDto.Password ?? user.Password;
                user.Description = userUpdateDto.Description ?? user.Description;
                user.Image = userUpdateDto.Image ?? user.Image;
                user.Position = userUpdateDto.Position ?? user.Position;
                user.RolId = userUpdateDto.RolId.HasValue ? userUpdateDto.RolId.Value : user.RolId;
                user.IdUserModification = userUpdateDto.IdUser;
                user.IsPublished = userUpdateDto.IsPublished.HasValue ? userUpdateDto.IsPublished.Value : user.IsPublished;
                user.ModificationDate = DateTime.Now;
                user.IsDeleted = userUpdateDto.IsDeleted.HasValue ? userUpdateDto.IsDeleted.Value : user.IsDeleted;
                user.DeletedDate = (userUpdateDto.IsDeleted.HasValue && userUpdateDto.IsDeleted ==  true) ? DateTime.Now  : user.DeletedDate;

                await this.userRepository.Update(user);

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

                User user = new User()
                {
                    FirstName =    userAddDto.FirstName,
                    LastName =     userAddDto.LastName,
                    Email =        userAddDto.Email,
                    PhoneNumber =  userAddDto.PhoneNumber,
                    Password =     userAddDto.Password,
                    Description =  userAddDto.Description,
                    Image =        userAddDto.Image,
                    Position =     userAddDto.Position,
                    RolId =        userAddDto.RolId,
                    IdUserCreate = userAddDto.IdUser,
                    CreationDate = DateTime.Now,
                    IsPublished =  true,
                    IsDeleted =    false
                };
                    
                await this.userRepository.Save(user);

                UserAddResponse userData = new UserAddResponse();
                userData.Id = user.Id;

                this.result.Data = userData;

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
    }
}
