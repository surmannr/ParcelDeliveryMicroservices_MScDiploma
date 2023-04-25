using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using PackageTracking.DAL.Repositories;

namespace PackageTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageTrackingController : ControllerBase
    {
        private readonly IPackageTrackingRepository _repository;

        public PackageTrackingController(IPackageTrackingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetShipping")]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingRequestDto>> GetShipping(string id)
        {
            var shipping = await _repository.GetShipping(id);
            return Ok(shipping);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShippingRequestDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ShippingRequestDto>> UpdateShipping([FromBody] ShippingRequestDto shipping)
        {
            var updatedShipping = await _repository.UpdateShipping(shipping);
            return Ok(updatedShipping);
        }

        [HttpDelete("{id}", Name = "DeleteShipping")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteShipping(string id)
        {
            await _repository.DeleteShipping(id);
            return Ok();
        }
    }
}
