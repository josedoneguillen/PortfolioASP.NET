using System;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities.Security;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Portfolio.Infraestructure.Core;

namespace Portfolio.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async Task<User> UserLogin(string email, string password)
        {
            User user = new User();
            try
            {
                user = await this._context.Users.SingleOrDefaultAsync(us => (us.Email == email && us.Password == Encrypt.GetSHA512(password)) && (!us.IsDeleted && us.IsPublished));

            }
            catch (Exception ex)
            {

                this._logger.LogError("Error obteniendo el usuario.", ex.Message);
            }

            return user;
        }

        public async override Task<IEnumerable<User>> GetAll() 
        {
            List<User> users = new List<User>();

            try
            {
                users = await this._context.Users.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los usuarios", ex.ToString());
            }

            return users;
        }

        public async override Task<User> GetEntityByID(int Id)
        {
            User user = new User();

            try
            {
                user = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los usuarios", ex.ToString());
            }

            return user;
        }

        public async override Task Save(User entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            { 
                this._logger.LogError("Ocurrio un error guardando el usuario ", ex.ToString());
            }
            
        }

        public async override Task Update(User entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando el usuario ", ex.ToString());
            }

        }
    }
}

