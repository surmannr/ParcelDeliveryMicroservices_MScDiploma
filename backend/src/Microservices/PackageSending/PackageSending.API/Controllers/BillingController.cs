using Common.Dto;
using Common.Paging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Billing.Commands;
using PackageSending.BL.Features._Billing.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BillingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BillingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BillingDto>>> GetBillings([FromQuery] PagingParameter parameter)
        {
            var billings = await _mediator.Send(new GetAllBillings.Query()
            {
                PageSize = parameter.PageSize,
                PageNumber = parameter.PageNumber,
            });
            return Ok(billings);
        }

        [HttpGet("{id}", Name = "GetBillingById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BillingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<BillingDto>> GetBillingById(string id)
        {
            var billing = await _mediator.Send(new GetBillingById.Query()
            {
                Id = id
            });
            return Ok(billing);
        }

        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(IEnumerable<BillingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BillingDto>>> GetBillingsByUserId(string id, [FromQuery] PagingParameter parameter)
        {
            var billings = await _mediator.Send(new GetAllBillingsByUserId.Query() 
            { 
                UserId = id,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
            });
            return Ok(billings);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BillingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<BillingDto>> CreateBilling([FromBody] NewBillingDto billing)
        {
            var id = await _mediator.Send(new AddNewBilling.Command()
            {
                NewBilling = billing
            });
            return CreatedAtRoute("GetBillingById", new { id = id }, billing);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BillingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateBilling([FromQuery] string id, [FromBody] NewBillingDto billing)
        {
            var result = await _mediator.Send(new EditBilling.Command()
            {
                ModifiedBilling = billing,
                Id = id
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BillingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteBilling(string id)
        {
            var result = await _mediator.Send(new DeleteBilling.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
