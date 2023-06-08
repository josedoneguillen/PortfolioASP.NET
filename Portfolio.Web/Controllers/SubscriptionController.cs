using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionApiService subscriptionApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<SubscriptionController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public SubscriptionController(ISubscriptionApiService subscriptionApiService,
                                  IConfiguration configuration,
                                  ILogger<SubscriptionController> logger)
        {
            this.subscriptionApiService = subscriptionApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: SubscriptionController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<SubscriptionModel> subscriptionList = new CoreListResponse<SubscriptionModel>();

            try
            {
                subscriptionList = await this.subscriptionApiService.GetSubscriptions();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(subscriptionList.Data);
        }

        // GET: SubscriptionController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<SubscriptionModel> subscriptionGet = new CoreGetResponse<SubscriptionModel>();

            try
            {

                subscriptionGet = await this.subscriptionApiService.GetSubscription(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(subscriptionGet.Data);
        }

        // GET: SubscriptionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubscriptionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubscriptionSaveRequest subscriptionSave)
        {
            try
            {

                var result = await this.subscriptionApiService.SaveSubscription(subscriptionSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscriptionController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var subscriptionGet = await this.subscriptionApiService.GetSubscription(id);

                SubscriptionSaveRequest subscriptionSave = new SubscriptionSaveRequest()
                {
                    Id = subscriptionGet.Data.Id,
                    IsPublished = subscriptionGet.Data.IsPublished,
                    IsDeleted = subscriptionGet.Data.IsDeleted,
                    Email = subscriptionGet.Data.Email,
                    OptOut = subscriptionGet.Data.OptOut
                };


                return View(subscriptionSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SubscriptionController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubscriptionSaveRequest subscriptionSave)
        {
            try
            {

                await this.subscriptionApiService.UpdateSubscription(subscriptionSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubscriptionController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                SubscriptionSaveRequest subscriptionSave = new SubscriptionSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.subscriptionApiService.UpdateSubscription(subscriptionSave);

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