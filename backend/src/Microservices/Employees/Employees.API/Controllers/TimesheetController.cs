using Employees.API.Data;
using Employees.API.Dto;
using Employees.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly EmployeesDbContext dbContext;

        public TimesheetController(EmployeesDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<List<TimesheetDto>> Get([FromQuery] string userId)
        {
            return await dbContext.Timesheets
                .Where(x => x.UserId == userId)
                .Select(x => new TimesheetDto
                {
                    UserId = x.UserId,
                    Id = x.Id,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Days = x.DaysArray,
                    Note = x.Note,
                })
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TimesheetDto timesheet)
        {
            var newTimesheet = new Timesheet()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = timesheet.UserId,
                DateFrom = timesheet.DateFrom,
                DateTo = timesheet.DateTo,
                Days = String.Join(";", timesheet.Days.Select(p => p.ToString()).ToArray()),
                Note = timesheet.Note,
            };
            dbContext.Timesheets.Add(newTimesheet);
            await dbContext.SaveChangesAsync();
            return Ok(newTimesheet);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var timesheet = await dbContext.Timesheets.FirstOrDefaultAsync(x => x.Id == id);
            if (timesheet == null)
            {
                dbContext.Timesheets.Remove(timesheet);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
