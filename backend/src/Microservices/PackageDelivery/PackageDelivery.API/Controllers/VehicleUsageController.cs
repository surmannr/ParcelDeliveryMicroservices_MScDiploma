using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._VehicleUsage.Queries;
using PackageDelivery.DAL.Entities;
using PackageDelivery.DAL.Repositories;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleUsageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVehicleUsageRepository _repository; //TODO megszüntetni majd
        public VehicleUsageController(IMediator mediator, IVehicleUsageRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleUsageDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehicleUsageDto>>> GetShippings()
        {
            var vehicleUsages = await _mediator.Send(new GetAllVehicleUsages.Query());
            return Ok(vehicleUsages);
        }

        [HttpPost]
        [ProducesResponseType(typeof(VehicleUsage), StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleUsage>> CreateShipping([FromBody] VehicleUsage vehicleUsage)
        {
            await _repository.CreateVehicleUsage(vehicleUsage);
            return CreatedAtRoute("GetShipping", new { id = vehicleUsage.Id }, vehicleUsage);
        }

        /* *
         * 
         * [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ShippingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ShippingDto>>> GetShippings()
        {
            var shippings = await _mediator.Send(new GetAllShippings.Query());
            return Ok(shippings);
        }

        [HttpGet("{id}", Name = "GetShipping")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ShippingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingDto>> GetShippingById(string id)
        {
            var shipping = await _repository.GetShippingById(id); // TODO
            if (shipping == null) { return NotFound(); }
            return Ok(shipping);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShippingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingDto>> CreateShipping([FromBody] Shipping shipping)
        {
            await _repository.CreateShipping(shipping);
            return CreatedAtRoute("GetShipping", new {id = shipping.Id}, shipping);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ShippingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateShipping([FromBody] Shipping shipping)
        {
            return Ok(await _repository.UpdateShipping(shipping));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ShippingDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteShipping(string id)
        {
            return Ok(await _repository.DeleteShipping(id));
        }
         * 
         * */
    }
}
