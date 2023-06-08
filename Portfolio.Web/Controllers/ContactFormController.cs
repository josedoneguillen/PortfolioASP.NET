using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class ContactFormController : Controller
    {
        private readonly IContactFormApiService contactFormApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<ContactFormController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public ContactFormController(IContactFormApiService contactFormApiService,
                                  IConfiguration configuration,
                                  ILogger<ContactFormController> logger)
        {
            this.contactFormApiService = contactFormApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: ContactFormController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<ContactFormModel> contactFormList = new CoreListResponse<ContactFormModel>();

            try
            {
                contactFormList = await this.contactFormApiService.GetContactForms();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(contactFormList.Data);
        }

        // GET: ContactFormController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<ContactFormModel> contactFormGet = new CoreGetResponse<ContactFormModel>();

            try
            {

                contactFormGet = await this.contactFormApiService.GetContactForm(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(contactFormGet.Data);
        }

        // GET: ContactFormController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactFormController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ContactFormSaveRequest contactFormSave)
        {
            try
            {

                var result = await this.contactFormApiService.SaveContactForm(contactFormSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactFormController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var contactFormGet = await this.contactFormApiService.GetContactForm(id);

                ContactFormSaveRequest contactFormSave = new ContactFormSaveRequest()
                {
                    Id = contactFormGet.Data.Id,
                    IsPublished = contactFormGet.Data.IsPublished,
                    IsDeleted = contactFormGet.Data.IsDeleted,
                    Name = contactFormGet.Data.Name,
                    Email = contactFormGet.Data.Email,
                    Subject = contactFormGet.Data.Subject,
                    Message = contactFormGet.Data.Message
                };


                return View(contactFormSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ContactFormController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ContactFormSaveRequest contactFormSave)
        {
            try
            {

                await this.contactFormApiService.UpdateContactForm(contactFormSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactFormController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                ContactFormSaveRequest contactFormSave = new ContactFormSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.contactFormApiService.UpdateContactForm(contactFormSave);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }

    }
}