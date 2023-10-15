using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._VehicleUsage.Commands;
using PackageDelivery.BL.Features._VehicleUsage.Queries;
using PackageDelivery.DAL.Entities.Filters;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VehicleUsageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public VehicleUsageController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VehicleUsageDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VehicleUsageDto>>> GetVehicleUsages([FromQuery] VehicleUsageFilter parameter)
        {
            var vehicleUsages = await _mediator.Send(_mapper.Map<GetAllVehicleUsages.Query>(parameter));
            return Ok(vehicleUsages);
        }
     
        [HttpGet("employee/{employeeid}", Name = "GetVehicleUsageByEmployeeId")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(VehicleUsageDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VehicleUsageDto>>> GetVehicleUsageByEmployeeId(string employeeid, [FromQuery] VehicleUsageFilter parameter)
        {
            var query = _mapper.Map<GetVehicleUsagesByEmployeeId.Query>(parameter);
            query.EmployeeId = employeeid;
            var vehicleUsages = await _mediator.Send(query);
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
