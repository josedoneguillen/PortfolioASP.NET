using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Experience;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        // GET: api/<ExperienceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.experienceService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<ExperienceController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.experienceService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<ExperienceController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ExperienceAddDto experience)
        {
            var result = await this.experienceService.SaveExperience(experience);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<ExperienceController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ExperienceUpdateDto experience)
        {
            var result = await this.experienceService.ModifyExperience(experience);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
