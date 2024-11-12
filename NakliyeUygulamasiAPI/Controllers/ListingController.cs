using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NakliyeUygulamasi.Application.Features.Commands.Listing.CreateListing;
using System.Net;

namespace NakliyeUygulamasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListingController : ControllerBase
    {

        readonly IMediator _mediator;

        public ListingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateListing(CreateListingCommandRequest createListingCommandRequest)
        {
            CreateListingCommandResponse response = await _mediator.Send(createListingCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
