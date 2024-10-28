using MediatR;
using Microsoft.AspNetCore.Mvc;
using NakliyeUygulamasi.Application.Features.Commands.Address.CreateDeliveryAddress;
using NakliyeUygulamasi.Application.Features.Commands.Address.CreatePickupAddress;
using NakliyeUygulamasi.Application.Features.Queries.Address.GetDistrictsForProvince;
using NakliyeUygulamasi.Application.Features.Queries.Address.GetNeighbourhoodForDistrict;
using NakliyeUygulamasi.Application.Features.Queries.Address.GetProvinceList;
using System.Net;

namespace NakliyeUygulamasiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinceList([FromQuery] GetProvinceListQueryRequest getProvinceListQueryRequest)
        {
            GetProvinceListQueryResponse response = await _mediator.Send(getProvinceListQueryRequest);
            return Ok(response);
        }

        [HttpGet("districts/{provinceId}")]
        public async Task<IActionResult> GetDistrictsForProvince([FromRoute] GetDistrictsForProvinceQueryRequest getDistrictsForProvinceQueryRequest)
        {
            GetDistrictsForProvinceQueryResponse response = await _mediator.Send(getDistrictsForProvinceQueryRequest);
            return Ok(response);
        }

        [HttpGet("neighbourhood/{districtId}")]
        public async Task<IActionResult> GetNeighbourhoodForDistrict([FromRoute] GetNeighbourhoodForDistrictQueryRequest getNeighbourhoodForDistrictQueryRequest)
        {
            GetNeighbourhoodForDistrictQueryResponse response = await _mediator.Send(getNeighbourhoodForDistrictQueryRequest);
            return Ok(response);
        }

        [HttpPost("delivery")]

        public async Task<IActionResult> CreateDeliveryAddress(CreateDeliveryAddressCommandRequest createDeliveryAddressCommandRequest)
        {
            CreateDeliveryAddressCommandResponse response = await _mediator.Send(createDeliveryAddressCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("pickup")]

        public async Task<IActionResult> CreatePickupAddress(CreatePickupAddressCommandRequest createPickupAddressCommandRequest)
        {
            CreatePickupAddressCommandResponse response = await _mediator.Send(createPickupAddressCommandRequest);
            return StatusCode((int)HttpStatusCode.Created); 
        }
    }
}
