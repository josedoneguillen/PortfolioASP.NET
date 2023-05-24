using System;
using Portfolio.Application.Dtos.Category;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Extensions
{
    public static class CategoryExtension
    {
        public static Category ConvertCategoryAddDtoToCategory(this CategoryAddDto categoryAddDto)
        {
            return new Category()
            {
                Name = categoryAddDto.Name,
                Description = categoryAddDto.Description,
                IdUserCreate = categoryAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = categoryAddDto.IsPublished.HasValue ? categoryAddDto.IsPublished.Value : true,
                IsDeleted = false
            };
        }
        public static Category ConvertCategoryUpdateDtoToCategory(this Category category, CategoryUpdateDto categoryUpdateDto)
        {
            category.Name = categoryUpdateDto.Name ?? category.Name;
            category.Description = categoryUpdateDto.Description ?? category.Description;
            category.IdUserModification = categoryUpdateDto.IdUser;
            category.IsPublished = categoryUpdateDto.IsPublished.HasValue ? categoryUpdateDto.IsPublished.Value : category.IsPublished;
            category.ModificationDate = DateTime.Now;
            category.IsDeleted = categoryUpdateDto.IsDeleted.HasValue ? categoryUpdateDto.IsDeleted.Value : category.IsDeleted;
            category.DeletedDate = (categoryUpdateDto.IsDeleted.HasValue && categoryUpdateDto.IsDeleted == true) ? DateTime.Now : category.DeletedDate;

            return category;
        }
        public static CategoryGetModel CreateCategoryGetModel(this Category category)
        {
            return new Models.CategoryGetModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

        }
    }
}
