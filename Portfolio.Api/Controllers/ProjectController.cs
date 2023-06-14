using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Project;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.projectService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.projectService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProjectAddDto project)
        {
            var result = await this.projectService.SaveProject(project);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<ProjectController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProjectUpdateDto project)
        {
            var result = await this.projectService.ModifyProject(project);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
