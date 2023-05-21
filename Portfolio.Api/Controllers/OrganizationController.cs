using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Organization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        // GET: api/<OrganizationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.organizationService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.organizationService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<OrganizationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] OrganizationAddDto organization)
        {
            var result = await this.organizationService.SaveOrganization(organization);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<OrganizationController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] OrganizationUpdateDto organization)
        {
            var result = await this.organizationService.ModifyOrganization(organization);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
