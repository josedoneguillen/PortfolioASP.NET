using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Certification;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService certificationService;

        public CertificationController(ICertificationService certificationService)
        {
            this.certificationService = certificationService;
        }

        // GET: api/<CertificationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.certificationService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<CertificationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.certificationService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<CertificationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CertificationAddDto certification)
        {
            var result = await this.certificationService.SaveCertification(certification);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<CertificationController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CertificationUpdateDto certification)
        {
            var result = await this.certificationService.ModifyCertification(certification);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
