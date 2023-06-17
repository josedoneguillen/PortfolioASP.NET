using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models.Requests;
using System.Security.Claims;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System;

namespace Portfolio.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthApiService authApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public AuthController(IAuthApiService authApiService,
                                  IConfiguration configuration,
                                  ILogger<AuthController> logger)
        {
            this.authApiService = authApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: AuthController/Create
        public ActionResult Login()
        {
                string username = Request.Cookies["FirstName"];

            if (!String.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        // POST: AuthController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(AuthLoginRequest authSave)
        {
            try
            {

                var result = await this.authApiService.Login(authSave);

                if (result.success)
                {
                    // Set session data
                    Response.Cookies.Append("FirstName", result.Data.FirstName);

                    return RedirectToAction("Index", "Home");
                }
                else {
                    TempData["LoginErrorMessage"] = result.message;
                    return RedirectToAction(nameof(Login));
                }
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("FirstName");
            return RedirectToAction("Login", "Auth");
        }

    }
}