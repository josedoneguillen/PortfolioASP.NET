using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using Portfolio.Infrastructure.Context;
using Portfolio.Infrastructure.Core;
using Portfolio.Infrastructure.Interfaces;


namespace Portfolio.Infrastructure.Repositories
{
    public class ContactFormRepository : BaseRepository<ContactForm>, IContactFormRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContactFormRepository> _logger;
        public ContactFormRepository(ApplicationDbContext context, ILogger<ContactFormRepository> logger) : base(context)
        {
            this._context = context;
            this._logger = logger;
        }

        public async override Task<IEnumerable<ContactForm>> GetAll()
        {
            List<ContactForm> contactForms = new List<ContactForm>();

            try
            {
                contactForms = await this._context.ContactForms.Where(u => !u.IsDeleted).ToListAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las formas de contacto", ex.ToString());
            }

            return contactForms;
        }

        public async override Task<ContactForm> GetEntityByID(int Id)
        {
            ContactForm contactForm = new ContactForm();

            try
            {
                contactForm = await base.GetEntityByID(Id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("Error obteniendo las formas de contacto", ex.ToString());
            }

            return contactForm;
        }

        public async override Task Save(ContactForm entities)
        {
            try
            {
                await base.Save(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error guardando la forma de contacto ", ex.ToString());
            }

        }

        public async override Task Update(ContactForm entities)
        {
            try
            {
                await base.Update(entities);
                await base.SaveChanges();
            }
            catch (Exception ex)
            {
                this._logger.LogError("Ocurrio un error modificando la forma de contacto ", ex.ToString());
            }

        }
    }
}

