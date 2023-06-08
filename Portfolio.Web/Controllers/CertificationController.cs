using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class CertificationController : Controller
    {
        private readonly ICertificationApiService certificationApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<CertificationController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public CertificationController(ICertificationApiService certificationApiService,
                                  IConfiguration configuration,
                                  ILogger<CertificationController> logger)
        {
            this.certificationApiService = certificationApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: CertificationController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<CertificationModel> certificationList = new CoreListResponse<CertificationModel>();

            try
            {
                certificationList = await this.certificationApiService.GetCertifications();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(certificationList.Data);
        }

        // GET: CertificationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<CertificationModel> certificationGet = new CoreGetResponse<CertificationModel>();

            try
            {

                certificationGet = await this.certificationApiService.GetCertification(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(certificationGet.Data);
        }

        // GET: CertificationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CertificationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CertificationSaveRequest certificationSave)
        {
            try
            {

                var result = await this.certificationApiService.SaveCertification(certificationSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var certificationGet = await this.certificationApiService.GetCertification(id);

                CertificationSaveRequest certificationSave = new CertificationSaveRequest()
                {
                    Id = certificationGet.Data.Id,
                    IsPublished = certificationGet.Data.IsPublished,
                    IsDeleted = certificationGet.Data.IsDeleted,
                    Title = certificationGet.Data.Title,
                    OrganizationId = certificationGet.Data.Id,
                    DateIssued = certificationGet.Data.DateIssued,
                    CredentialId = certificationGet.Data.CredentialId,
                    CredentialUrl = certificationGet.Data.CredentialUrl,
                    Description = certificationGet.Data.Description,
                    ImageUrl = certificationGet.Data.ImageUrl,
                    FileUrl = certificationGet.Data.FileUrl
                };


                return View(certificationSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CertificationController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CertificationSaveRequest certificationSave)
        {
            try
            {

                await this.certificationApiService.UpdateCertification(certificationSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CertificationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                CertificationSaveRequest certificationSave = new CertificationSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.certificationApiService.UpdateCertification(certificationSave);

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