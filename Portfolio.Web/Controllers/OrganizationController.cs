using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationApiService organizationApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<OrganizationController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public OrganizationController(IOrganizationApiService organizationApiService,
                                  IConfiguration configuration,
                                  ILogger<OrganizationController> logger)
        {
            this.organizationApiService = organizationApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: OrganizationController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<OrganizationModel> organizationList = new CoreListResponse<OrganizationModel>();

            try
            {
                organizationList = await this.organizationApiService.GetOrganizations();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(organizationList.Data);
        }

        // GET: OrganizationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<OrganizationModel> organizationGet = new CoreGetResponse<OrganizationModel>();

            try
            {

                organizationGet = await this.organizationApiService.GetOrganization(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(organizationGet.Data);
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrganizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrganizationSaveRequest organizationSave)
        {
            try
            {

                var result = await this.organizationApiService.SaveOrganization(organizationSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var organizationGet = await this.organizationApiService.GetOrganization(id);

                OrganizationSaveRequest organizationSave = new OrganizationSaveRequest()
                {
                    Id = organizationGet.Data.Id,
                    IsPublished = organizationGet.Data.IsPublished,
                    IsDeleted = organizationGet.Data.IsDeleted,
                    Name = organizationGet.Data.Name,
                    Description = organizationGet.Data.Description,
                    Website = organizationGet.Data.Website,
                    LogoUrl = organizationGet.Data.LogoUrl,
                };


                return View(organizationSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: OrganizationController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrganizationSaveRequest organizationSave)
        {
            try
            {

                await this.organizationApiService.UpdateOrganization(organizationSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                OrganizationSaveRequest organizationSave = new OrganizationSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.organizationApiService.UpdateOrganization(organizationSave);

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