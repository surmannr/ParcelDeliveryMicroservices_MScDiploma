﻿using Common.Dto;
using Common.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Features._ShippingRequest.Commands;
using PackageDelivery.BL.Features._ShippingRequest.Queries;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShippingRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShippingRequestDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ShippingRequestDto>>> GetShippingRequests([FromQuery] PagingParameter parameter)
        {
            var vehicles = await _mediator.Send(new GetAllShippingRequests.Query()
            {
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
            });
            return Ok(vehicles);
        }

        [HttpGet("{id}", Name = "GetShippingRequestById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingRequestDto>> GetShippingRequestById(string id)
        {
            var vehicle = await _mediator.Send(new GetShippingRequestById.Query()
            {
                Id = id
            });
            return Ok(vehicle);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingRequestDto>> CreateShippingRequest([FromBody] ShippingRequestDto shippingRequest)
        {
            var id = await _mediator.Send(new AddNewShippingRequest.Command()
            {
                NewShippingRequest = shippingRequest
            });
            shippingRequest.Id = id;
            return CreatedAtRoute("GetShippingRequestById", new { id = id }, shippingRequest);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateShippingRequest([FromBody] ShippingRequestDto shippingRequest)
        {
            var result = await _mediator.Send(new EditShippingRequest.Command()
            {
                ModifiedShippingRequest = shippingRequest
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteShippingRequest(string id)
        {
            var result = await _mediator.Send(new DeleteShippingRequest.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
