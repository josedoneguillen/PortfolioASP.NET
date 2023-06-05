﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;
using static System.Net.WebRequestMethods;

namespace Portfolio.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiService userApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<UserController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public UserController(IUserApiService userApiService,
                                  IConfiguration configuration,
                                  ILogger<UserController> logger)
        {
            this.userApiService = userApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            UserListResponse userList = new UserListResponse();

            try
            {
                userList = await this.userApiService.GetUsers();

                //using (var httpclient = new HttpClient(this.clientHandler))
                //{
                //    var response = await httpclient.GetAsync("http://localhost:5062/api/User");

                //    if (response.IsSuccessStatusCode)
                //    {
                //        string resp = await response.Content.ReadAsStringAsync();

                //        userList = JsonConvert.DeserializeObject<UserListResponse>(resp);

                //    }
                //}
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(userList.Data);
        }

        // GET: UserController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            UserGetResponse userGet = new UserGetResponse();

            try
            {

                userGet = await this.userApiService.GetUser(id);

                //using (var httpclient = new HttpClient(this.clientHandler))
                //{

                //    var url = "http://localhost:5062/api/User/" + id;

                //    var response = await httpclient.GetAsync(url);

                //    if (response.IsSuccessStatusCode)
                //    {
                //        string resp = await response.Content.ReadAsStringAsync();

                //        userGet = JsonConvert.DeserializeObject<UserListResponse>(resp);

                //    }
                //}
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(userGet.Data);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserSaveRequest userSave)
        {
            try
            {

                var result = await this.userApiService.SaveUser(userSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var userGet = await this.userApiService.GetUser(id);

            UserSaveRequest userSave = new UserSaveRequest()
            {
                Id = userGet.Data.Id,
                FirstName = userGet.Data.FirstName,
                LastName = userGet.Data.LastName,
                Email = userGet.Data.Email,
                PhoneNumber = userGet.Data.PhoneNumber,
                Description = userGet.Data.Description,
                Image = userGet.Data.Image,
                Position = userGet.Data.Position,
                RolId = userGet.Data.RolId
            };


            return View(userSave);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserSaveRequest userSave)
        {
            try
            {

                await this.userApiService.UpdateUser(userSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5

    }
}