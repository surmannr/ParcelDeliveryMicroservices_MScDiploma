using AutoMapper;
using Common.Dto;
using Common.Entity.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageSending.BL.Features._ShippingOption.Commands;
using PackageSending.BL.Features._ShippingOption.Queries;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "EmployeeServer, CustomerServer")]
    public class ShippingOptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ShippingOptionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShippingOptionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ShippingOptionDto>>> GetShippingOptions([FromQuery] ShippingOptionFilter parameter)
        {
            var shippingOptions = await _mediator.Send(_mapper.Map<GetAllShippingOptions.Query>(parameter));
            return Ok(shippingOptions);
        }

        [HttpGet("{id}", Name = "GetShippingOptionById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ShippingOptionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingOptionDto>> GetShippingOptionById(int id)
        {
            var shippingOption = await _mediator.Send(new GetShippingOptionById.Query()
            {
                Id = id
            });
            return Ok(shippingOption);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShippingOptionDto), StatusCodes.Status200OK)]
        [Authorize(Roles = "Office assistant")]
        public async Task<ActionResult<ShippingOptionDto>> CreateShippingOption([FromBody] ShippingOptionDto shippingOption)
        {
            var id = await _mediator.Send(new AddNewShippingOption.Command()
            {
                NewShippingOption = shippingOption
            });
            shippingOption.Id = id;
            return CreatedAtRoute("GetShippingOptionById", new { id = id }, shippingOption);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ShippingOptionDto), StatusCodes.Status200OK)]
        [Authorize(Roles = "Office assistant")]
        public async Task<ActionResult<bool>> UpdateShippingOption([FromBody] ShippingOptionDto shippingOption)
        {
            var result = await _mediator.Send(new EditShippingOption.Command()
            {
                ModifiedShippingOption = shippingOption
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ShippingOptionDto), StatusCodes.Status200OK)]
        [Authorize(Roles = "Office assistant")]
        public async Task<ActionResult<bool>> DeleteShippingOption(int id)
        {
            var result = await _mediator.Send(new DeleteShippingOption.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
