using AutoMapper;
using Common.Dto;
using Common.Entity.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Features._Currency.Commands;
using PackageSending.BL.Features._Currency.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "EmployeeServer, CustomerServer")]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CurrencyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CurrencyDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetCurrencies([FromQuery] CurrencyFilter parameter)
        {
            var currencies = await _mediator.Send(_mapper.Map<GetAllCurrencies.Query>(parameter));
            return Ok(currencies);
        }

        [HttpGet("{id}", Name = "GetCurrencyById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CurrencyDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<CurrencyDto>> GetCurrencyById(int id)
        {
            var currency = await _mediator.Send(new GetCurrencyById.Query()
            {
                Id = id
            });
            return Ok(currency);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CurrencyDto), StatusCodes.Status200OK)]
        [Authorize(Roles = "Office assistant")]
        public async Task<ActionResult<CurrencyDto>> CreateVehicle([FromBody] CurrencyDto currency)
        {
            var id = await _mediator.Send(new AddNewCurrency.Command()
            {
                NewCurrency = currency
            });
            currency.Id = id;
            return CreatedAtRoute("GetCurrencyById", new { id = id }, currency);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CurrencyDto), StatusCodes.Status200OK)]
        [Authorize(Roles = "Office assistant")]
        public async Task<ActionResult<bool>> UpdateCurrency([FromBody] CurrencyDto currency)
        {
            var result = await _mediator.Send(new EditCurrency.Command()
            {
                ModifiedCurrency = currency
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CurrencyDto), StatusCodes.Status200OK)]
        [Authorize(Roles = "Office assistant")]
        public async Task<ActionResult<bool>> DeleteCurrency(int id)
        {
            var result = await _mediator.Send(new DeleteCurrency.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
