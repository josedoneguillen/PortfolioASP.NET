using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.Rol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService rolService;

        public RolController(IRolService rolService)
        {
            this.rolService = rolService;
        }

        // GET: api/<RolController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.rolService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.rolService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<RolController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolAddDto rol)
        {
            var result = await this.rolService.SaveRol(rol);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<RolController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RolUpdateDto rol)
        {
            var result = await this.rolService.ModifyRol(rol);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }

    }
}
