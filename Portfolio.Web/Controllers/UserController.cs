using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Web.Models.Response;

namespace Portfolio.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<UserController> logger;
        private HttpClientHandler httpHandler;
        public UserController(IConfiguration configuration, ILogger<UserController> logger) 
        { 
            this.configuration = configuration;
            this.logger = logger;
            this. httpHandler = new HttpClientHandler();
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            UserListResponse userList = new UserListResponse();
            try
            {
                using (var httpClient = new HttpClient(this.httpHandler))
                {
                    var response = await httpClient.GetAsync("http://localhost:5179/api/User");

                    if (response.IsSuccessStatusCode) 
                    {
                        string resp = await response.Content.ReadAsStringAsync();
                        userList = JsonConvert.DeserializeObject<UserListResponse>(resp);
                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }

            return View(userList.Data);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
