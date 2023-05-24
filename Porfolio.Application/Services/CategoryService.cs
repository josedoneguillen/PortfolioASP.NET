using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Category;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ILogger<CategoryService> logger;
        protected ServiceResult result;
        public CategoryService(ICategoryRepository categoryRepository, ILogger<CategoryService> logger)
        {
            this.categoryRepository = categoryRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getCategories();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo las categorias";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getCategories(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo la subscripción";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyCategory(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                // Field Validations
                if (categoryUpdateDto.Id == 0)
                {
                    this.result.Message = "Id de la subscripción a modificar es requerido";
                    this.result.Success = false;
                    return result;
                }

                if (categoryUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return result;
                }

                Category category = await this.categoryRepository.GetEntityByID(categoryUpdateDto.Id);


                if (category == null)
                {
                    this.result.Message = "Esta Subscrición no existe";
                    this.result.Success = false;
                    return result;
                }

                category = category.ConvertCategoryUpdateDtoToCategory(categoryUpdateDto);

                await this.categoryRepository.Update(category);

                this.result.Message = "Subscrición actualizada correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando la subscripción";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveCategory(CategoryAddDto categoryAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(categoryAddDto.Name))
                {
                    this.result.Message = "Nombre es requerido";
                    this.result.Success = false;
                    return result;
                }

                Category category = categoryAddDto.ConvertCategoryAddDtoToCategory();


                await this.categoryRepository.Save(category);

                this.result.Message = "Categoria agregada correctamente";
                this.result.Data = category.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando la categoria";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.CategoryGetModel>> getCategories(int? Id = null)
        {
            List<Models.CategoryGetModel>? categories = new List<Models.CategoryGetModel>();
            try
            {
                categories = (from category in (await this.categoryRepository.GetAll())
                                 where category.Id == Id || !Id.HasValue
                                 select category.CreateCategoryGetModel()).ToList();
            }
            catch (Exception ex)
            {
                categories = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo las categorias", ex.ToString());
            }

            return categories;
        }
    }
}
