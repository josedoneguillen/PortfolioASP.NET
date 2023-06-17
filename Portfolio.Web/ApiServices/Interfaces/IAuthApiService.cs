using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<CoreGetResponse<AuthLoginModel>> Login(AuthLoginRequest authLoginRequest);
    }
}