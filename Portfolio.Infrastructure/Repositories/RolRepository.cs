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

namespace Portfolio.Infrastructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RolRepository> _logger;
        public RolRepository(ApplicationDbContext context, ILogger<RolRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<Rol>> GetAll()
        {
            List<Rol> rols = new List<Rol>();

            try
            {
                rols = await this._context.Roles.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los rol", ex.ToString());
            }

            return rols;
        }

        public async override Task<Rol> GetEntityByID(int Id)
        {
            Rol rol = new Rol();

            try
            {
                rol = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los rol", ex.ToString());
            }

            return rol;
        }

        public async override Task Save(Rol entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando el rol ", ex.ToString());
            }

        }

        public async override Task Update(Rol entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando el rol ", ex.ToString());
            }

        }
    }
}

