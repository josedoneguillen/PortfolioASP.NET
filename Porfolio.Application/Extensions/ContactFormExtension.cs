using System;
using Portfolio.Application.Dtos.ContactForm;
using Portfolio.Application.Dtos.Subscription;
using Portfolio.Application.Models;
using Portfolio.Domain.Entities;
using Portfolio.Domain.Entities.Security;

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
                IsPublished = contactFormAddDto.IsPublished,
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
            contactForm.IdUserDelete = (contactFormUpdateDto.IsDeleted == true) ? contactFormUpdateDto.IdUser : 0;
            contactForm.IsPublished = contactFormUpdateDto.IsPublished;
            contactForm.ModificationDate = DateTime.Now;
            contactForm.IsDeleted = contactFormUpdateDto.IsDeleted ? contactFormUpdateDto.IsDeleted : contactForm.IsDeleted;
            contactForm.DeletedDate = (contactFormUpdateDto.IsDeleted == true) ? DateTime.Now : contactForm.DeletedDate;

            return contactForm;
        }
        public static ContactFormGetModel CreateContactFormGetModel(this ContactForm contactForm)
        {
            return new Models.ContactFormGetModel()
            {
                Name = contactForm.Name,
                Email = contactForm.Email,
                Subject = contactForm.Subject,
                Message = contactForm.Message,
                IsPublished = contactForm.IsPublished,
                IsDeleted = contactForm.IsDeleted
            };

        }
    }
}
