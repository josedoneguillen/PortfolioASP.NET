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
    public class CertificationCategoryRepository : BaseRepository<CertificationCategory>, ICertificationCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CertificationCategoryRepository> _logger;
        public CertificationCategoryRepository(ApplicationDbContext context, ILogger<CertificationCategoryRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<CertificationCategory>> GetAll()
        {
            List<CertificationCategory> certificationCategories = new List<CertificationCategory>();

            try
            {
                certificationCategories = await this._context.CertificationsCategories.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las certificaciones", ex.ToString());
            }

            return certificationCategories;
        }

        public async override Task<CertificationCategory> GetEntityByID(int Id)
        {
            CertificationCategory certificationCategory = new CertificationCategory();

            try
            {
                certificationCategory = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las categorias de certificaciones", ex.ToString());
            }

            return certificationCategory;
        }

        public async override Task Save(CertificationCategory entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la categoria de certificaciones", ex.ToString());
            }

        }

        public async override Task Save(CertificationCategory[] entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando las categoria de certificaciones ", ex.ToString());
            }

        }

        public async override Task Update(CertificationCategory entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la categoria de certificaciones ", ex.ToString());
            }

        }

        public async override void DeleteById(int certificationId)
        {
            try
            {
                List<CertificationCategory> certificationCategories = await this._context.CertificationsCategories.Where(cc => cc.CertificationId == certificationId).ToListAsync();
                base.Delete(certificationCategories.ToArray());
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error eliminando las categorias de certificaciones ", ex.ToString());
            }

        }


    }
}

