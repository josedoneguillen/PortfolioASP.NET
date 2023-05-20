using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.Rol;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository rolRepository;
        private readonly ILogger<RolService> logger;
        public RolService(IRolRepository rolRepository, ILogger<RolService> logger)
        {
            this.rolRepository = rolRepository;
            this.logger = logger;
        }
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> IRolService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<RolAddResponse> IRolService.ModifyRol(RolUpdateDto rolUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<RolAddResponse> IRolService.SaveRol(RolAddDto rolAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
