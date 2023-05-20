using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.User;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IRolRepository rolRepository;
        private readonly ILogger<UserService> logger;
        public UserService(IUserRepository userRepository, IRolRepository rolRepository, ILogger<UserService> logger)
        { 
            this.userRepository = userRepository;
            this.rolRepository = rolRepository;
            this.logger = logger;
        }
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResult> Get()
        {
            ServiceResult result = new ServiceResult();
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

                result.Data = query;
            }
            catch (Exception ex)
            {
                // Send Notification
                result.Success = false;
                result.Message = "Error obteniendo los usuarios";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return result;
        }

        Task<ServiceResult> IUserService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<UserAddResponse> IUserService.ModifyUser(UserUpdateDto userUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<UserAddResponse> IUserService.SaveUser(UserAddDto userAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
