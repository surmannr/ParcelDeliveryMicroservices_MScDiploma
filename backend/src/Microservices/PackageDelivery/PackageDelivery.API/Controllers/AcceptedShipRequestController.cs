﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._AcceptedShipRequest.Commands;
using PackageDelivery.BL.Features._AcceptedShipRequest.Queries;
using PackageDelivery.DAL.Entities.Filters;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcceptedShipRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AcceptedShipRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AcceptedShippingRequestDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AcceptedShippingRequestDto>>> GetAccceptedShipRequests([FromQuery] AcceptedShippingRequestFilter parameter)
        {
            var acceptedShippingRequests = await _mediator.Send(_mapper.Map<GetAllAcceptedShipRequests.Query>(parameter));
            return Ok(acceptedShippingRequests);
        }

        [HttpGet("{id}", Name = "GetAcceptedShipRequestById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(AcceptedShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<AcceptedShippingRequestDto>> GetAcceptedShipRequestById(string id)
        {
            var acceptedShippingRequest = await _mediator.Send(new GetAcceptedShipRequestById.Query()
            {
                Id = id
            });
            return Ok(acceptedShippingRequest);
        }

        [HttpGet("employee/{employeeid}", Name = "GetAcceptedShipRequestByEmployeeId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(AcceptedShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AcceptedShippingRequestDto>>> GetAcceptedShipRequestByEmployeeId(string employeeid, [FromQuery] AcceptedShippingRequestFilter parameter)
        {
            var query = _mapper.Map<GetAllAcceptedShipRequestByEmployeeId.Query>(parameter);
            query.EmployeeId = employeeid;
            var acceptedShippingRequests = await _mediator.Send(query);
            return Ok(acceptedShippingRequests);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AcceptedShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<AcceptedShippingRequestDto>> CreateAcceptedShipRequest([FromBody] AcceptedShippingRequestDto acceptedShipping)
        {
            var id = await _mediator.Send(new AddNewAcceptedShipRequest.Command()
            {
                NewAcceptedShipRequest = acceptedShipping
            });
            acceptedShipping.Id = id;
            return CreatedAtRoute("GetAcceptedShipRequestById", new { id = id }, acceptedShipping);
        }

        [HttpPut]
        [ProducesResponseType(typeof(AcceptedShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateAcceptedShipRequest([FromBody] AcceptedShippingRequestDto acceptedShipping)
        {
            var result = await _mediator.Send(new EditAcceptedShipRequest.Command()
            {
                ModifiedAcceptedShipRequest = acceptedShipping
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AcceptedShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteAcceptedShipRequest(string id)
        {
            var result = await _mediator.Send(new DeleteAcceptedShipRequest.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
