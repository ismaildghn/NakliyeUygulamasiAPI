using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NakliyeUygulamasi.Application.Features.Commands.Listing.CreateListing;
using NakliyeUygulamasi.Application.Features.Queries.Listing.GetAllListings;
using NakliyeUygulamasi.Application.Features.Queries.Listing.GetByIdListing;
using NakliyeUygulamasi.Application.Features.Queries.Listing.GetListingsByLocation;
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

        [HttpGet]
        public async Task<IActionResult> GetAllListings([FromQuery]GetAllListingsQueryRequest getAllListingsQueryRequest)
        {
            GetAllListingsQueryResponse response = await _mediator.Send(getAllListingsQueryRequest);
            return Ok(response);
        }

        [HttpGet("{ListingId}")]     
        public async Task<IActionResult> GetByIdListing([FromRoute]GetByIdListingQueryRequest getByIdListingQueryRequest)
        {
            GetByIdListingQueryResponse response = await _mediator.Send(getByIdListingQueryRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListingsByLocation([FromQuery]GetListingsByLocationQueryRequest getListingsByLocationQueryRequest)
        {
            GetListingsByLocationQueryResponse response = await _mediator.Send(getListingsByLocationQueryRequest);
            return Ok(response);
        }
    }
}
