using MediatR;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._Vehicle.Commands;
using PackageDelivery.BL.Features._Vehicle.Queries;
using PackageDelivery.BL.Features._VehicleUsage.Commands;
using PackageDelivery.BL.Features._VehicleUsage.Queries;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
        {
            var vehicles = await _mediator.Send(new GetAllVehicles.Query());
            return Ok(vehicles);
        }

        [HttpGet("{id}", Name = "GetVehicleById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleDto>> GetVehicleById(string id)
        {
            var vehicle = await _mediator.Send(new GetVehicleById.Query()
            {
                Id = id
            });
            return Ok(vehicle);
        }

        [HttpPost]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleDto>> CreateVehicle([FromBody] VehicleDto vehicle)
        {
            var id = await _mediator.Send(new AddNewVehicle.Command()
            {
                NewVehicle = vehicle
            });
            vehicle.Id = id;
            return CreatedAtRoute("GetVehicleById", new { id = id }, vehicle);
        }

        [HttpPut]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateVehicle([FromBody] VehicleDto vehicle)
        {
            var result = await _mediator.Send(new EditVehicle.Command()
            {
                ModifiedVehicle = vehicle
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteVehicleUsage(string id)
        {
            var result = await _mediator.Send(new DeleteVehicle.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
