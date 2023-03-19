using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackageSending.DAL;
using PackageSending.DAL.Entities;

namespace PackageSending.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly PackageSendingDbContext dbContext;

        public CurrencyController(PackageSendingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Currency>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            var currencies = await dbContext.Currencies.ToListAsync();
            return Ok(currencies);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Currency), StatusCodes.Status200OK)]
        public async Task<ActionResult<Currency>> CreateShipping([FromBody] Currency currency)
        {
            await dbContext.Currencies.AddAsync(currency);
            await dbContext.SaveChangesAsync();
            return CreatedAtRoute("GetCurrency", new { id = currency.Id }, currency);
        }
    }
}
