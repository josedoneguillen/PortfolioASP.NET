using System;
using System.Text;
using System.Security.Cryptography;
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
                Password = userAddDto.Password.EncryptToMD5(),
                Description = userAddDto.Description,
                Image = userAddDto.Image,
                Position = userAddDto.Position,
                RolId = userAddDto.RolId,
                IdUserCreate = userAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = true,
                IsDeleted = false
            };
        }
        public static User ConvertUserUpdateDtoToUser(this User user, UserUpdateDto userUpdateDto)
        {
            user.FirstName = userUpdateDto.FirstName ?? user.FirstName;
            user.LastName = userUpdateDto.LastName ?? user.LastName;
            user.Email = userUpdateDto.Email ?? user.Email;
            user.PhoneNumber = userUpdateDto.PhoneNumber ?? user.PhoneNumber;
            user.Password = userUpdateDto.Password.EncryptToMD5() ?? user.Password;
            user.Description = userUpdateDto.Description ?? user.Description;
            user.Image = userUpdateDto.Image ?? user.Image;
            user.Position = userUpdateDto.Position ?? user.Position;
            user.RolId = userUpdateDto.RolId.HasValue ? userUpdateDto.RolId.Value : user.RolId;
            user.IdUserModification = userUpdateDto.IdUser;
            user.IsPublished = userUpdateDto.IsPublished.HasValue ? userUpdateDto.IsPublished.Value : user.IsPublished;
            user.ModificationDate = DateTime.Now;
            user.IsDeleted = userUpdateDto.IsDeleted.HasValue ? userUpdateDto.IsDeleted.Value : user.IsDeleted;
            user.DeletedDate = (userUpdateDto.IsDeleted.HasValue && userUpdateDto.IsDeleted == true) ? DateTime.Now : user.DeletedDate;

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
                RolId = user.RolId
            };

        }

        public static string EncryptToMD5(this string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return password;
            }

                using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
