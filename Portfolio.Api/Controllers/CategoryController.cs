using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Category;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.categoryService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.categoryService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryAddDto category)
        {
            var result = await this.categoryService.SaveCategory(category);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategoryUpdateDto category)
        {
            var result = await this.categoryService.ModifyCategory(category);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
