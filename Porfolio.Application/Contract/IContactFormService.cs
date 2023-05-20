using Portfolio.Application.Core;
using Portfolio.Application.Dtos.ContactForm;
using Portfolio.Application.Responses;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IContactFormService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ContactFormAddResponse> SaveContactForm(ContactFormAddDto contactFormAddDto);
        Task<ContactFormAddResponse> ModifyContactForm(ContactFormUpdateDto contactFormUpdateDto);
    }
}
