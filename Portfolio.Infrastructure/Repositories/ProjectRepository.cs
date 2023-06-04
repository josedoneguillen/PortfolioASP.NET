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
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProjectRepository> _logger;
        public ProjectRepository(ApplicationDbContext context, ILogger<ProjectRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async Task<Project> GetProjectCategories(int projectId)
        {
            return this._context.Projects.Include(cd => cd.ProjectCategories)
                .FirstOrDefault(cd => cd.Id == projectId);
        }

        public async override Task<IEnumerable<Project>> GetAll()
        {
            List<Project> projects = new List<Project>();

            try
            {
                projects = await this._context.Projects.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los proyectos", ex.ToString());
            }

            return projects;
        }

        public async override Task<Project> GetEntityByID(int Id)
        {
            Project project = new Project();

            try
            {
                project = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo los proyectos", ex.ToString());
            }

            return project;
        }

        public async override Task Save(Project entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando el proyecto ", ex.ToString());
            }

        }

        public async override Task Update(Project entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando el proyecto ", ex.ToString());
            }

        }
    }
}

