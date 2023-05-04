using System;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            this._logger = logger;
        }

        public async override Task save(User entities)
        {
            try
            {
                await base.save(entities);
            }
            catch (Exception ex)
            { 
                this._logger.LogError("Ocurrio un error guardando el usuario ", ex.ToString());
            }
            
        }
    }
}

