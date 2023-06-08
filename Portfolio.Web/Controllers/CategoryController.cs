using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService categoryApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<CategoryController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public CategoryController(ICategoryApiService categoryApiService,
                                  IConfiguration configuration,
                                  ILogger<CategoryController> logger)
        {
            this.categoryApiService = categoryApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<CategoryModel> categoryList = new CoreListResponse<CategoryModel>();

            try
            {
                categoryList = await this.categoryApiService.GetCategorys();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(categoryList.Data);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<CategoryModel> categoryGet = new CoreGetResponse<CategoryModel>();

            try
            {

                categoryGet = await this.categoryApiService.GetCategory(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(categoryGet.Data);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategorySaveRequest categorySave)
        {
            try
            {

                var result = await this.categoryApiService.SaveCategory(categorySave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var categoryGet = await this.categoryApiService.GetCategory(id);

                CategorySaveRequest categorySave = new CategorySaveRequest()
                {
                    Id = categoryGet.Data.Id,
                    IsPublished = categoryGet.Data.IsPublished,
                    IsDeleted = categoryGet.Data.IsDeleted,
                    Name = categoryGet.Data.Name,
                    Description = categoryGet.Data.Description
                };


                return View(categorySave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: CategoryController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategorySaveRequest categorySave)
        {
            try
            {

                await this.categoryApiService.UpdateCategory(categorySave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                CategorySaveRequest categorySave = new CategorySaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.categoryApiService.UpdateCategory(categorySave);

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