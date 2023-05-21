using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;


namespace Portfolio.Infrastructure.Repositories
{
    public class ExperienceRepository : BaseRepository<Experience>, IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ExperienceRepository> _logger;
        public ExperienceRepository(ApplicationDbContext context, ILogger<ExperienceRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<Experience>> GetAll()
        {
            List<Experience> experiences = new List<Experience>();

            try
            {
                experiences = await this._context.Experiences.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las experiencias", ex.ToString());
            }

            return experiences;
        }

        public async override Task<Experience> GetEntityByID(int Id)
        {
            Experience experience = new Experience();

            try
            {
                experience = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las experiencias", ex.ToString());
            }

            return experience;
        }

        public async override Task Save(Experience entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la experiencia ", ex.ToString());
            }

        }

        public async override Task Update(Experience entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la experiencia ", ex.ToString());
            }

        }
    }
}

