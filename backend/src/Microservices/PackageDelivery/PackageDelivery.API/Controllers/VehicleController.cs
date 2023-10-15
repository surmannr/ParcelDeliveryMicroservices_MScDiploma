using AutoMapper;
using Common.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._AcceptedShipRequest.Queries;
using PackageDelivery.BL.Features._Vehicle.Commands;
using PackageDelivery.BL.Features._Vehicle.Queries;
using PackageDelivery.DAL.Entities.Filters;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public VehicleController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles([FromQuery] VehicleFilter parameter)
        {
            var vehicles = await _mediator.Send(_mapper.Map<GetAllVehicles.Query>(parameter));
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
