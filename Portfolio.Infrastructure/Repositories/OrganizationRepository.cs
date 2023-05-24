using System;
using Microsoft.Extensions.Logging;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Infrastructure.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<OrganizationRepository> _logger;
        public OrganizationRepository(ApplicationDbContext context, ILogger<OrganizationRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<Organization>> GetAll()
        {
            List<Organization> organizations = new List<Organization>();

            try
            {
                organizations = await this._context.Organizations.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las organizaciones", ex.ToString());
            }

            return organizations;
        }

        public async override Task<Organization> GetEntityByID(int Id)
        {
            Organization organization = new Organization();

            try
            {
                organization = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las organizaciones", ex.ToString());
            }

            return organization;
        }

        public async override Task Save(Organization entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la organización ", ex.ToString());
            }

        }

        public async override Task Update(Organization entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la organización ", ex.ToString());
            }

        }
    }
}

