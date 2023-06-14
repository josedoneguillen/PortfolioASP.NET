using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Portfolio.Application.Core;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.ContactForm;
using Portfolio.Infrastructure.Interfaces;
using Portfolio.Domain.Entities;
using Portfolio.Application.Extensions;
using System.Collections.Generic;

namespace Portfolio.Application.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IContactFormRepository contactFormRepository;
        private readonly ILogger<ContactFormService> logger;
        protected ServiceResult result;
        public ContactFormService(IContactFormRepository contactFormRepository, ILogger<ContactFormService> logger)
        {
            this.contactFormRepository = contactFormRepository;
            this.result = new ServiceResult();
            this.logger = logger;
        }

        public async Task<ServiceResult> Get()
        {
            try
            {
                this.result.Data = await this.getContactForms();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo las formas de contacto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> GetById(int Id)
        {
            try
            {
                this.result.Data = (await this.getContactForms(Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error obteniendo la forma de contacto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> ModifyContactForm(ContactFormUpdateDto contactFormUpdateDto)
        {
            try
            {
                // Field Validations
                if (contactFormUpdateDto.Id == 0)
                {
                    this.result.Message = "Id de la forma de contacto a modificar es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                if (contactFormUpdateDto.IdUser == 0)
                {
                    this.result.Message = "Id del usuario que realiza la modificación es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                ContactForm contactForm = await this.contactFormRepository.GetEntityByID(contactFormUpdateDto.Id);


                if (contactForm == null)
                {
                    this.result.Message = "Esta forma de contacto no existe";
                    this.result.Success = false;
                    return this.result;
                }

                contactForm = contactForm.ConvertContactFormUpdateDtoToContactForm(contactFormUpdateDto);

                await this.contactFormRepository.Update(contactForm);

                this.result.Message = "forma de contacto actualizada correctamente";

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error modificando la forma de contacto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        public async Task<ServiceResult> SaveContactForm(ContactFormAddDto contactFormAddDto)
        {
            try
            {
                // Field Validations
                if (string.IsNullOrEmpty(contactFormAddDto.Name))
                {
                    this.result.Message = "Nombre es requerido";
                    this.result.Success = false;
                    return this.result;
                }

                ContactForm contactForm = contactFormAddDto.ConvertContactFormAddDtoToContactForm();


                await this.contactFormRepository.Save(contactForm);

                this.result.Message = "Forma de contacto agregada correctamente";
                this.result.Data = contactForm.Id;

            }
            catch (Exception ex)
            {
                // Send Notification
                this.result.Success = false;
                this.result.Message = "Error agregando la forma de contacto";
                this.logger.Log(LogLevel.Error, $" {result.Message}", ex.ToString());
            }

            return this.result;
        }

        private async Task<List<Models.ContactFormGetModel>> getContactForms(int? Id = null)
        {
            List<Models.ContactFormGetModel>? contactForms = new List<Models.ContactFormGetModel>();
            try
            {
                contactForms = (from contactForm in (await this.contactFormRepository.GetAll())
                               where contactForm.Id == Id || !Id.HasValue
                               select contactForm.CreateContactFormGetModel()).ToList();
            }
            catch (Exception ex)
            {
                contactForms = null;
                this.logger.Log(LogLevel.Error, "Error obteniendo las formas de contacto", ex.ToString());
            }

            return contactForms;
        }
    }
}
