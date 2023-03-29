using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackageSending.BL.Dto;
using PackageSending.BL.Features._Currency.Commands;
using PackageSending.BL.Features._Currency.Queries;
using PackageSending.DAL;
using PackageSending.DAL.Entities;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CurrencyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CurrencyDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetCurrencies()
        {
            var currencies = await _mediator.Send(new GetAllCurrencies.Query());
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
