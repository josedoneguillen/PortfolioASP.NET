﻿using Portfolio.Application.Core;
using Portfolio.Application.Dtos.User;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IUserService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<UserAddResponse> SaveUser(UserAddDto userAddDto);
        Task<UserAddResponse> ModifyUser(UserUpdateDto userUpdateDto);
    }
}
