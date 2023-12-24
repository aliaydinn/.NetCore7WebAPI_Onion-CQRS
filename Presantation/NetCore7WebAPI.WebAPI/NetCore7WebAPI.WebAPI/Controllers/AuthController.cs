using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore7WebAPI.Application.Features.Auth.Command.Login;
using NetCore7WebAPI.Application.Features.Auth.Command.RefreshToken;
using NetCore7WebAPI.Application.Features.Auth.Command.Register;

namespace NetCore7WebAPI.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest registerCommandRequest)
        {
            await mediator.Send(registerCommandRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest loginCommandRequest)
        {
            var response = await mediator.Send(loginCommandRequest);
            return StatusCode(StatusCodes.Status200OK, response);

        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest refreshTokenCommandRequest)
        {
            var response = await mediator.Send(refreshTokenCommandRequest);
            return StatusCode(StatusCodes.Status200OK, response);

        }
    }
}
