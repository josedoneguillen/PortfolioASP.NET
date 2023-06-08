using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolApiService rolApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<RolController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public RolController(IRolApiService rolApiService,
                                  IConfiguration configuration,
                                  ILogger<RolController> logger)
        {
            this.rolApiService = rolApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: RolController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<RolModel> rolList = new CoreListResponse<RolModel>();

            try
            {
                rolList = await this.rolApiService.GetRols();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(rolList.Data);
        }

        // GET: RolController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<RolModel> rolGet = new CoreGetResponse<RolModel>();

            try
            {

                rolGet = await this.rolApiService.GetRol(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(rolGet.Data);
        }

        // GET: RolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RolSaveRequest rolSave)
        {
            try
            {

                var result = await this.rolApiService.SaveRol(rolSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var rolGet = await this.rolApiService.GetRol(id);

                RolSaveRequest rolSave = new RolSaveRequest()
                {
                    Id = rolGet.Data.Id,
                    IsPublished = rolGet.Data.IsPublished,
                    IsDeleted = rolGet.Data.IsDeleted,
                    Name = rolGet.Data.Name,
                    Description = rolGet.Data.Description,
                };


                return View(rolSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: RolController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RolSaveRequest rolSave)
        {
            try
            {

                await this.rolApiService.UpdateRol(rolSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                RolSaveRequest rolSave = new RolSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.rolApiService.UpdateRol(rolSave);

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