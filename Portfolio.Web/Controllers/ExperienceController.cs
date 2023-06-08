using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceApiService experienceApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<ExperienceController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public ExperienceController(IExperienceApiService experienceApiService,
                                  IConfiguration configuration,
                                  ILogger<ExperienceController> logger)
        {
            this.experienceApiService = experienceApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: ExperienceController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<ExperienceModel> experienceList = new CoreListResponse<ExperienceModel>();

            try
            {
                experienceList = await this.experienceApiService.GetExperiences();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(experienceList.Data);
        }

        // GET: ExperienceController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<ExperienceModel> experienceGet = new CoreGetResponse<ExperienceModel>();

            try
            {

                experienceGet = await this.experienceApiService.GetExperience(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(experienceGet.Data);
        }

        // GET: ExperienceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExperienceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ExperienceSaveRequest experienceSave)
        {
            try
            {

                var result = await this.experienceApiService.SaveExperience(experienceSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperienceController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var experienceGet = await this.experienceApiService.GetExperience(id);

                ExperienceSaveRequest experienceSave = new ExperienceSaveRequest()
                {
                    Id = experienceGet.Data.Id,
                    IsPublished = experienceGet.Data.IsPublished,
                    IsDeleted = experienceGet.Data.IsDeleted,
                    Title = experienceGet.Data.Title,
                    Description = experienceGet.Data.Description,
                    Company = experienceGet.Data.Company,
                    OrganizationId = experienceGet.Data.OrganizationId,
                    StartDate = experienceGet.Data.StartDate,
                    EndDate = experienceGet.Data.EndDate
                };


                return View(experienceSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ExperienceController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ExperienceSaveRequest experienceSave)
        {
            try
            {

                await this.experienceApiService.UpdateExperience(experienceSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExperienceController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                ExperienceSaveRequest experienceSave = new ExperienceSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.experienceApiService.UpdateExperience(experienceSave);

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