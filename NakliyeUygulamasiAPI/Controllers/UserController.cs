using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NakliyeUygulamasi.Application.Features.Commands.AppUser.CreateTransporter;

namespace NakliyeUygulamasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransporter(CreateTransporterCommandRequest createTransporterCommandRequest)
        {
            CreateTransporterCommandResponse response = await _mediator.Send(createTransporterCommandRequest);
            return Ok(response);
        }
    }
}
