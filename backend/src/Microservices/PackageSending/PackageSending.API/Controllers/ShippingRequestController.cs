using Common.Dto;
using Common.Paging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;
using PackageSending.BL.Features._ShipRequest.Commands;
using PackageSending.BL.Features._ShipRequest.Queries;

namespace PackageSending.API.Controllers
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
            var shippingRequests = await _mediator.Send(new GetAllShipRequests.Query()
            {
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
            });
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
        public async Task<ActionResult<IEnumerable<ShippingRequestDto>>> GetShippingRequestsByUserId(string id, [FromQuery] PagingParameter parameter)
        {
            var shippingRequests = await _mediator.Send(new GetAllShipRequestsByUserId.Query()
            {
                UserId = id,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
            });
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
