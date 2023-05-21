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
    public class ProjectCategoryRepository : BaseRepository<ProjectCategory>, IProjectCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectCategoryRepository> _logger;
        public ProjectCategoryRepository(ApplicationDbContext context, ILogger<ProjectCategoryRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<ProjectCategory>> GetAll()
        {
            List<ProjectCategory> projectCategories = new List<ProjectCategory>();

            try
            {
                projectCategories = await this._context.ProjectsCategories.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las categorias de proyectos", ex.ToString());
            }

            return projectCategories;
        }

        public async override Task<ProjectCategory> GetEntityByID(int Id)
        {
            ProjectCategory projectCategory = new ProjectCategory();

            try
            {
                projectCategory = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las categorias de proyectos", ex.ToString());
            }

            return projectCategory;
        }

        public async override Task Save(ProjectCategory entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la categoria del proyecto ", ex.ToString());
            }

        }

        public async override Task Update(ProjectCategory entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la categoria del proyecto ", ex.ToString());
            }

        }
    }
}

