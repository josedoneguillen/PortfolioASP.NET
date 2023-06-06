using System;
using Portfolio.Application.Dtos.Rol;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entities.Security;

namespace Portfolio.Application.Extensions
{
    public static class RolExtension
    {
        public static Rol ConvertRolAddDtoToRol(this RolAddDto rolAddDto)
        {
            return new Rol()
            {
                Name = rolAddDto.Name,
                Description = rolAddDto.Description,
                IdUserCreate = rolAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = rolAddDto.IsPublished,
                IsDeleted = false
            };
        }
        public static Rol ConvertRolUpdateDtoToRol(this Rol rol, RolUpdateDto rolUpdateDto)
        {
            rol.Name = rolUpdateDto.Name ?? rol.Name;
            rol.Description = rolUpdateDto.Description ?? rol.Description;
            rol.IdUserModification = rolUpdateDto.IdUser;
            rol.IdUserDelete = (rolUpdateDto.IsDeleted == true) ? rolUpdateDto.IdUser : 0;
            rol.IsPublished = rolUpdateDto.IsPublished;
            rol.ModificationDate = DateTime.Now;
            rol.IsDeleted = rolUpdateDto.IsDeleted ? rolUpdateDto.IsDeleted : rol.IsDeleted;
            rol.DeletedDate = (rolUpdateDto.IsDeleted == true) ? DateTime.Now : rol.DeletedDate;

            return rol;
        }
        public static RolGetModel CreateRolGetModel(this Rol rol)
        {
            return new Models.RolGetModel()
            {
                Id = rol.Id,
                Name = rol.Name,
                Description = rol.Description,
                IsPublished = rol.IsPublished,
                IsDeleted = rol.IsDeleted
            };

        }
    }
}
