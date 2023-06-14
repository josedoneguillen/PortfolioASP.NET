using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.BlogPost;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            this.blogPostService = blogPostService;
        }

        // GET: api/<BlogPostController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.blogPostService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<BlogPostController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.blogPostService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<BlogPostController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BlogPostAddDto blogPost)
        {
            var result = await this.blogPostService.SaveBlogPost(blogPost);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<BlogPostController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] BlogPostUpdateDto blogPost)
        {
            var result = await this.blogPostService.ModifyBlogPost(blogPost);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
