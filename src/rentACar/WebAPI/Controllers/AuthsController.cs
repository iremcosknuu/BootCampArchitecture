using Application.Features.Auths.Commands.Login;
using Application.Features.Auths.Commands.Register;
using Core.Security.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginCommand loginCommand = new LoginCommand {
                UserForLoginDto = userForLoginDto
            };

            var result = await Mediator.Send(loginCommand);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            var result = await Mediator.Send(registerCommand);
            return Created("",result);
        }
    }
}
