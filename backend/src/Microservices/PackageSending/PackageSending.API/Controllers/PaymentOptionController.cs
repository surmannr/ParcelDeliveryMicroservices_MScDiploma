using AutoMapper;
using Common.Dto;
using Common.Entity.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Features._PaymentOption.Commands;
using PackageSending.BL.Features._PaymentOption.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "EmployeeServer, CustomerServer")]
    public class PaymentOptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PaymentOptionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PaymentOptionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PaymentOptionDto>>> GetPaymentOptions([FromQuery] PaymentOptionFilter parameter)
        {
            var paymentOptions = await _mediator.Send(_mapper.Map<GetAllPaymentOptions.Query>(parameter));
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
        [Authorize(Roles = "Office assistant")]
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
        [Authorize(Roles = "Office assistant")]
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
        [Authorize(Roles = "Office assistant")]
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
