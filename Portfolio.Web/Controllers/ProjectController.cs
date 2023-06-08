using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectApiService projectApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProjectController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public ProjectController(IProjectApiService projectApiService,
                                  IConfiguration configuration,
                                  ILogger<ProjectController> logger)
        {
            this.projectApiService = projectApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: ProjectController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<ProjectModel> projectList = new CoreListResponse<ProjectModel>();

            try
            {
                projectList = await this.projectApiService.GetProjects();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(projectList.Data);
        }

        // GET: ProjectController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<ProjectModel> projectGet = new CoreGetResponse<ProjectModel>();

            try
            {

                projectGet = await this.projectApiService.GetProject(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(projectGet.Data);
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectSaveRequest projectSave)
        {
            try
            {

                var result = await this.projectApiService.SaveProject(projectSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var projectGet = await this.projectApiService.GetProject(id);

                ProjectSaveRequest projectSave = new ProjectSaveRequest()
                {
                    Id = projectGet.Data.Id,
                    IsPublished = projectGet.Data.IsPublished,
                    IsDeleted = projectGet.Data.IsDeleted,
                    Title = projectGet.Data.Title,
                    Slug = projectGet.Data.Slug,
                    Description = projectGet.Data.Description,
                    ImageUrl = projectGet.Data.ImageUrl,
                    GithubUrl = projectGet.Data.GithubUrl,
                    DemoUrl = projectGet.Data.DemoUrl,
                    OrganizationId = projectGet.Data.OrganizationId,
                    StartDate = projectGet.Data.StartDate,
                    EndDate = projectGet.Data.EndDate,
                    IsFeatured = projectGet.Data.IsFeatured,
                    IsOngoing = projectGet.Data.IsOngoing
                };


                return View(projectSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ProjectController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProjectSaveRequest projectSave)
        {
            try
            {

                await this.projectApiService.UpdateProject(projectSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                ProjectSaveRequest projectSave = new ProjectSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.projectApiService.UpdateProject(projectSave);

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