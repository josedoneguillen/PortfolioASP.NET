using System;
using Portfolio.Infraestructure.Core;
using Portfolio.Application.Dtos.User;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities.Security;

namespace Portfolio.Application.Extensions
{
    public static class UserExtension
    {
        public static User ConvertUserAddDtoToUser(this UserAddDto userAddDto) 
        {
            return new User()
            {
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                Email = userAddDto.Email,
                PhoneNumber = userAddDto.PhoneNumber,
                Password = Encrypt.GetSHA512(userAddDto.Password),
                Description = userAddDto.Description,
                Image = userAddDto.Image,
                Position = userAddDto.Position,
                RolId = userAddDto.RolId,
                IdUserCreate = userAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = userAddDto.IsPublished,
                IsDeleted = false
            };
        }
        public static User ConvertUserUpdateDtoToUser(this User user, UserUpdateDto userUpdateDto)
        {
            user.FirstName = userUpdateDto.FirstName ?? user.FirstName;
            user.LastName = userUpdateDto.LastName ?? user.LastName;
            user.Email = userUpdateDto.Email ?? user.Email;
            user.PhoneNumber = userUpdateDto.PhoneNumber ?? user.PhoneNumber;
            user.Password = Encrypt.GetSHA512(userUpdateDto.Password) ?? user.Password;
            user.Description = userUpdateDto.Description ?? user.Description;
            user.Image = userUpdateDto.Image ?? user.Image;
            user.Position = userUpdateDto.Position ?? user.Position;
            user.RolId = userUpdateDto.RolId == null? userUpdateDto.RolId.Value : user.RolId;
            user.IdUserModification = userUpdateDto.IdUser;
            user.IdUserDelete = userUpdateDto.IsDeleted == true ? userUpdateDto.IdUser : user.IdUserDelete;
            user.IsPublished = userUpdateDto.IsPublished;
            user.ModificationDate = DateTime.Now;
            user.IsDeleted = userUpdateDto.IsDeleted;
            user.DeletedDate = (userUpdateDto.IsDeleted == true) ? DateTime.Now : user.DeletedDate;

            return user;
        }
        public static UserGetModel CreateUserGetModel(this User user, Rol rol)
        {
            return new Models.UserGetModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Description = user.Description,
                Image = user.Image,
                Position = user.Position,
                Rol = rol.Name,
                RolId = user.RolId,
                IsPublished = user.IsPublished, 
                IsDeleted = user.IsDeleted
            };

        }
    }
}
