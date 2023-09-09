using Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.BL.Features._ShippingRequest.Commands;
using PackageDelivery.BL.Services;

namespace PackageDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;
        public ScheduleController(ISchedulingService schedulingService)
        {
            _schedulingService = schedulingService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Schedule()
        {
            await _schedulingService.Schedule();

            return Ok();
        }
    }
}
