using Portfolio.Application.Core;
using Portfolio.Application.Dtos.ContactForm;
using System.Threading.Tasks;

namespace Portfolio.Application.Contract
{
    public interface IContactFormService
    {
        Task<ServiceResult> Get();
        Task<ServiceResult> GetById(int Id);
        Task<ServiceResult> SaveContactForm(ContactFormAddDto contactFormAddDto);
        Task<ServiceResult> ModifyContactForm(ContactFormUpdateDto contactFormUpdateDto);
    }
}
