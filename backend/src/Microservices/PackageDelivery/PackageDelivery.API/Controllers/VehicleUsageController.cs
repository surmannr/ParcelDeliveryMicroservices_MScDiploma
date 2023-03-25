using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._VehicleUsage.Commands;
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
        public VehicleUsageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleUsageDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehicleUsageDto>>> GetVehicleUsages()
        {
            var vehicleUsages = await _mediator.Send(new GetAllVehicleUsages.Query());
            return Ok(vehicleUsages);
        }
     
        [HttpGet("{employeeid}", Name = "GetVehicleUsageByEmployeeId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(VehicleUsageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VehicleUsageDto>>> GetVehicleUsageByEmployeeId(string employeeid)
        {
            var vehicleUsages = await _mediator.Send(new GetVehicleUsagesByEmployeeId.Query()
            {
                EmployeeId = employeeid
            });
            return Ok(vehicleUsages);
        }

        [HttpGet("{id}", Name = "GetVehicleUsageById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(VehicleUsageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleUsageDto>> GetVehicleUsageById(string id)
        {
            var vehicleUsage = await _mediator.Send(new GetVehicleUsageById.Query()
            {
                Id = id
            });
            return Ok(vehicleUsage);
        }

        [HttpPost]
        [ProducesResponseType(typeof(VehicleUsageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<VehicleUsageDto>> CreateVehicleUsage([FromBody] NewVehicleUsageDto vehicleUsage)
        {
            var id = await _mediator.Send(new AddNewVehicleUsage.Command()
            {
                NewVehicleUsage = vehicleUsage
            });
            vehicleUsage.Id = id;
            return CreatedAtRoute("GetVehicleUsageById", new { id = id }, vehicleUsage);
        }

        [HttpPut]
        [ProducesResponseType(typeof(VehicleUsageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateVehicleUsage([FromBody] NewVehicleUsageDto vehicleUsage)
        {
            var result = await _mediator.Send(new EditVehicleUsage.Command()
            {
                ModifiedVehicleUsage = vehicleUsage
            });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VehicleUsageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteVehicleUsage(string id)
        {
            var result = await _mediator.Send(new DeleteVehicleUsage.Command()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
