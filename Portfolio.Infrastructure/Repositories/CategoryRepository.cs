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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;
        public CategoryRepository(ApplicationDbContext context, ILogger<CategoryRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<Category>> GetAll()
        {
            List<Category> categories = new List<Category>();

            try
            {
                categories = await this._context.Categories.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las categorias", ex.ToString());
            }

            return categories;
        }

        public async override Task<Category> GetEntityByID(int Id)
        {
            Category category = new Category();

            try
            {
                category = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las categorias", ex.ToString());
            }

            return category;
        }

        public async override Task Save(Category entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la categoria ", ex.ToString());
            }

        }

        public async override Task Update(Category entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la categoria ", ex.ToString());
            }

        }
    }
}

