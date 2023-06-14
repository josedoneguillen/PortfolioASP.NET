using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        { 
            this.userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.userService.Get();

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await this.userService.GetById(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserAddDto user)
        {
            var result = await this.userService.SaveUser(user);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserUpdateDto user)
        {
                var result = await this.userService.ModifyUser(user);

                if (!result.Success)
                {
                    return NotFound(result);
                }

                return Ok(result);
            
        }

    }
}
