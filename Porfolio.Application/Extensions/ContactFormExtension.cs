using System;
using Portfolio.Application.Dtos.ContactForm;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Extensions
{
    public static class ContactFormExtension
    {
        public static ContactForm ConvertContactFormAddDtoToContactForm(this ContactFormAddDto contactFormAddDto)
        {
            return new ContactForm()
            {
                Name = contactFormAddDto.Name,
                Email = contactFormAddDto.Email,
                Subject = contactFormAddDto.Subject,
                Message = contactFormAddDto.Message,
                IdUserCreate = contactFormAddDto.IdUser,
                CreationDate = DateTime.Now,
                IsPublished = true,
                IsDeleted = false
            };
        }
        public static ContactForm ConvertContactFormUpdateDtoToContactForm(this ContactForm contactForm, ContactFormUpdateDto contactFormUpdateDto)
        {
            contactForm.Name = contactFormUpdateDto.Name ?? contactForm.Name;
            contactForm.Email = contactFormUpdateDto.Email ?? contactForm.Email;
            contactForm.Subject = contactFormUpdateDto.Subject ?? contactForm.Subject;
            contactForm.Message = contactFormUpdateDto.Message ?? contactForm.Message;
            contactForm.IdUserModification = contactFormUpdateDto.IdUser;
            contactForm.IsPublished = contactFormUpdateDto.IsPublished.HasValue ? contactFormUpdateDto.IsPublished.Value : contactForm.IsPublished;
            contactForm.ModificationDate = DateTime.Now;
            contactForm.IsDeleted = contactFormUpdateDto.IsDeleted.HasValue ? contactFormUpdateDto.IsDeleted.Value : contactForm.IsDeleted;
            contactForm.DeletedDate = (contactFormUpdateDto.IsDeleted.HasValue && contactFormUpdateDto.IsDeleted == true) ? DateTime.Now : contactForm.DeletedDate;

            return contactForm;
        }
        public static ContactFormGetModel CreateContactFormGetModel(this ContactForm contactForm)
        {
            return new Models.ContactFormGetModel()
            {
                Name = contactForm.Name,
                Email = contactForm.Email,
                Subject = contactForm.Subject,
                Message = contactForm.Message
        };

        }
    }
}
