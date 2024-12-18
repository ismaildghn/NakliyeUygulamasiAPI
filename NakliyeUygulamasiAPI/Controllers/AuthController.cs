using MediatR;
using Microsoft.AspNetCore.Mvc;
using NakliyeUygulamasi.Application.Features.Commands.AppUser.RefreshTokenLogin;
using NakliyeUygulamasi.Application.Features.Commands.AppUser.UserLogin;

namespace NakliyeUygulamasiAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Login(UserLoginCommandRequest userLoginCommandRequest)
        {
            UserLoginCommandResponse response = await _mediator.Send(userLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        
        public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);
            return Ok(response);
        }
    }
}
