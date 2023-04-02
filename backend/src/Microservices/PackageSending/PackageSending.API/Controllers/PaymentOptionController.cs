using Common.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Package.Commands;
using PackageSending.BL.Features._Package.Queries;
using PackageSending.BL.Features._PaymentOption.Commands;
using PackageSending.BL.Features._PaymentOption.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentOptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentOptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PaymentOptionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PaymentOptionDto>>> GetPaymentOptions()
        {
            var paymentOptions = await _mediator.Send(new GetAllPaymentOptions.Query());
            return Ok(paymentOptions);
        }

        [HttpGet("{id}", Name = "GetPaymentOptionById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(PaymentOptionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentOptionDto>> GetPaymentOptionById(int id)
        {
            var paymentOption = await _mediator.Send(new GetPaymentOptionById.Query()
            {
                Id = id
            });
            return Ok(paymentOption);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaymentOptionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaymentOptionDto>> CreatePaymentOption([FromBody] PaymentOptionDto paymentOption)
        {
            var id = await _mediator.Send(new AddNewPaymentOption.Command()
            {
                NewPaymentOption = paymentOption
            });
            paymentOption.Id = id;
            return CreatedAtRoute("GetPaymentOptionById", new { id = id }, paymentOption);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PaymentOptionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdatePackage([FromBody] PaymentOptionDto paymentOption)
        {
            var result = await _mediator.Send(new EditPaymentOption.Command()
            {
                ModifiedPaymentOption = paymentOption
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PaymentOptionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeletePackage(int id)
        {
            var result = await _mediator.Send(new DeletePaymentOption.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
