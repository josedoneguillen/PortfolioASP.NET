using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Contract;
using Portfolio.Application.Dtos.User;
using Portfolio.Auth.Api.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        { 
            this.userService = userService;
            this.configuration = configuration;
        }

       
        // POST api/<AuthController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserLoginDto user)
        {
            var result = await this.userService.UserLogin(user);

            if (result.Success)
            {
                result.Data = TokenHelper.GetToken(result.Data, this.configuration["TokenInfo:SignKey"]);
            }
            else 
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
