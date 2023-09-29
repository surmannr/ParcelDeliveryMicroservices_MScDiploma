﻿using Common.Filter;
using Common.Paging;
using Employees.API.Data;
using Employees.API.Dto;
using Employees.API.Models;
using Employees.API.Models.Filters;
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
        public async Task<PagedResponse<TimesheetDto>> Get([FromQuery] TimesheetFilter pagingParameter)
        {
            return await dbContext.Timesheets
                .ExecuteFilterAndOrder(pagingParameter)
                .Select(x => new TimesheetDto
                {
                    UserId = x.UserId,
                    Id = x.Id,
                    DateFrom = x.DateFrom,
                    DateTo = x.DateTo,
                    Days = x.DaysArray,
                    Note = x.Note,
                })
                .ToPagedListAsync(pagingParameter);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TimesheetDto timesheet)
        {
            if (timesheet == null)
            {
                return BadRequest("Nem lehet null.");
            }

            if (timesheet.Days.Length == 0)
            {
                return BadRequest("Minimum 1 napot ki kell választani.");
            }

            var newTimesheet = new Timesheet()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = timesheet.UserId,
                DateFrom = timesheet.DateFrom,
                DateTo = timesheet.DateTo,
                Days = String.Join(";", timesheet.Days.Select(p => p.ToString() ?? "").ToArray()) ?? "",
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
            if (timesheet != null)
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
