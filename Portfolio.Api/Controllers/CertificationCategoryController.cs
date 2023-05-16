using Microsoft.AspNetCore.Mvc;
using Portfolio.Infrastructure.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificationCategoryController : ControllerBase
    {
        private readonly ICertificationCategoryRepository certificationCategoryRepository;

        public CertificationCategoryController(ICertificationCategoryRepository certificationCategoryRepository)
        {
            this.certificationCategoryRepository = certificationCategoryRepository;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await this.certificationCategoryRepository.GetAll();
            return Ok(roles);
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RolController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
