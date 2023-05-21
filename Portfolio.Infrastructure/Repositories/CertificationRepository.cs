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
    public class CertificationRepository : BaseRepository<Certification>, ICertificationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CertificationRepository> _logger;
        public CertificationRepository(ApplicationDbContext context, ILogger<CertificationRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<Certification>> GetAll()
        {
            List<Certification> certifications = new List<Certification>();

            try
            {
                certifications = await this._context.Certifications.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las certificaciones", ex.ToString());
            }

            return certifications;
        }

        public async override Task<Certification> GetEntityByID(int Id)
        {
            Certification certification = new Certification();

            try
            {
                certification = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las certificaciones", ex.ToString());
            }

            return certification;
        }

        public async override Task Save(Certification entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la certificación ", ex.ToString());
            }

        }
        
        public async override Task Update(Certification entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la certificación ", ex.ToString());
            }

        }
    }
}

