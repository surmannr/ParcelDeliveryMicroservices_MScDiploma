using AutoMapper;
using Common.Dto;
using Common.Entity.Filters;
using Common.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;
using PackageSending.BL.Features._ShippingOption.Queries;
using PackageSending.BL.Features._ShipRequest.Commands;
using PackageSending.BL.Features._ShipRequest.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShippingRequestController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ShippingRequestController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShippingRequestDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ShippingRequestDto>>> GetShippingRequests([FromQuery] ShippingRequestFilter parameter)
        {
            var shippingRequests = await _mediator.Send(_mapper.Map<GetAllShipRequests.Query>(parameter));
            return Ok(shippingRequests);
        }

        [HttpGet("{id}", Name = "GetShippingRequestById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingRequestDto>> GetShippingRequestById(string id)
        {
            var shippingRequest = await _mediator.Send(new GetShipRequestById.Query()
            {
                Id = id
            });
            return Ok(shippingRequest);
        }

        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ShippingRequestDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ShippingRequestDto>>> GetShippingRequestsByUserId(string id, [FromQuery] ShippingRequestFilter parameter)
        {
            var query = _mapper.Map<GetAllShipRequestsByUserId.Query>(parameter);
            query.UserId = id;
            var shippingRequests = await _mediator.Send(query);
            return Ok(shippingRequests);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingRequestDto>> CreateShippingRequest([FromBody] NewShippingRequestDto newShippingRequest)
        {
            var id = await _mediator.Send(new AddNewShipRequest.Command()
            {
                NewShipRequest = newShippingRequest
            });
            return CreatedAtRoute("GetShippingRequestById", new { id = id }, newShippingRequest);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateShippingRequest(string id,[FromBody] NewShippingRequestDto newShippingRequest)
        {
            var result = await _mediator.Send(new EditShipRequest.Command()
            {
                ModifiedShipping = newShippingRequest,
                Id = id
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteShippingRequest(string id)
        {
            var result = await _mediator.Send(new DeleteShipRequest.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
