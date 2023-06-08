using Microsoft.AspNetCore.Mvc;
using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.Models;
using Portfolio.Web.Models.Requests;
using Portfolio.Web.Models.Responses;

namespace Portfolio.Web.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostApiService blogPostApiService;
        private readonly IConfiguration configuration;
        private readonly ILogger<BlogPostController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public BlogPostController(IBlogPostApiService blogPostApiService,
                                  IConfiguration configuration,
                                  ILogger<BlogPostController> logger)
        {
            this.blogPostApiService = blogPostApiService;
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: BlogPostController
        public async Task<ActionResult> Index()
        {
            CoreListResponse<BlogPostModel> blogPostList = new CoreListResponse<BlogPostModel>();

            try
            {
                blogPostList = await this.blogPostApiService.GetBlogPosts();
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(blogPostList.Data);
        }

        // GET: BlogPostController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            CoreGetResponse<BlogPostModel> blogPostGet = new CoreGetResponse<BlogPostModel>();

            try
            {

                blogPostGet = await this.blogPostApiService.GetBlogPost(id);
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(blogPostGet.Data);
        }

        // GET: BlogPostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BlogPostSaveRequest blogPostSave)
        {
            try
            {

                var result = await this.blogPostApiService.SaveBlogPost(blogPostSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPostController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var blogPostGet = await this.blogPostApiService.GetBlogPost(id);

                BlogPostSaveRequest blogPostSave = new BlogPostSaveRequest()
                {
                    Id = blogPostGet.Data.Id,
                    IsPublished = blogPostGet.Data.IsPublished,
                    IsDeleted = blogPostGet.Data.IsDeleted,
                    Title = blogPostGet.Data.Title,
                    Slug = blogPostGet.Data.Slug,
                    Content = blogPostGet.Data.Content,
                    ImageUrl = blogPostGet.Data.ImageUrl
                };


                return View(blogPostSave);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: BlogPostController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(BlogPostSaveRequest blogPostSave)
        {
            try
            {

                await this.blogPostApiService.UpdateBlogPost(blogPostSave);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPostController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {

                BlogPostSaveRequest blogPostSave = new BlogPostSaveRequest()
                {
                    Id = id,
                    IsDeleted = true,
                    IdUser = 1
                };

                await this.blogPostApiService.UpdateBlogPost(blogPostSave);

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