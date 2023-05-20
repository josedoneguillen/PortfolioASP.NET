using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using System.Threading.Tasks;
using System.Linq;
using Portfolio.Application.Responses;
using Portfolio.Application.Dtos.ContactForm;
using Portfolio.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace Portfolio.Application.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IContactFormRepository contactFormRepository;
        private readonly ILogger<ContactFormService> logger;
        public ContactFormService(IContactFormRepository contactFormRepository, ILogger<ContactFormService> logger)
        {
            this.contactFormRepository = contactFormRepository;
            this.logger = logger;
        }
        public ServiceResult save()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResult> Get()
        {
            throw new System.NotImplementedException();
        }

        Task<ServiceResult> IContactFormService.GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        Task<ContactFormAddResponse> IContactFormService.ModifyContactForm(ContactFormUpdateDto contactFormUpdateDto)
        {
            throw new System.NotImplementedException();
        }

        Task<ContactFormAddResponse> IContactFormService.SaveContactForm(ContactFormAddDto contactFormAddDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
