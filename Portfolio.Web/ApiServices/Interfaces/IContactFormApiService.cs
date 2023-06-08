using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.ApiServices.Interfaces
{
    public interface IContactFormApiService
    {
        Task<CoreListResponse<ContactFormModel>> GetContactForms();
        Task<CoreGetResponse<ContactFormModel>> GetContactForm(int Id);
        Task<CoreAddResponse> SaveContactForm(ContactFormSaveRequest contactFormRequest);
        Task<CoreResponseModel> UpdateContactForm(ContactFormSaveRequest contactFormRequest);
    }
}