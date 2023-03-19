using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackageTracking.DAL.Entities;
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
        [ProducesResponseType(typeof(Shipping), StatusCodes.Status200OK)]
        public async Task<ActionResult<Shipping>> GetShipping(string id)
        {
            var shipping = await _repository.GetShipping(id);
            return Ok(shipping);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Shipping), StatusCodes.Status200OK)]
        public async Task<ActionResult<Shipping>> UpdateShipping([FromBody] Shipping shipping)
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
