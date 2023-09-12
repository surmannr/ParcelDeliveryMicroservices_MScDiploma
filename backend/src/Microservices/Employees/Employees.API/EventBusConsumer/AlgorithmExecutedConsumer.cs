using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Dto;
using Employees.API.Data;
using EventBus.Messages.EventObjects;
using EventBus.Messages.Events;
using MassTransit;
using MassTransit.Transports;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Employees.API.EventBusConsumer
{
    public class AlgorithmExecutedConsumer : IConsumer<AlgorithmExecutedEvent>
    {
        private readonly EmployeesDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public AlgorithmExecutedConsumer(EmployeesDbContext dbContext, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<AlgorithmExecutedEvent> context)
        {
            var numberOfDriver = context.Message.NumberOfDriversNeed;
            var rnd = new Random();

            if (numberOfDriver > 0)
            {
                var random = rnd.Next();
                var date = context.Message.Date;
                var dayNumber = context.Message.DayNumber.ToString();

                var employees = await _dbContext.Users
                .Include(x => x.Timesheets)
                .Where(x => x.Timesheets.Any(y => y.DateFrom <= date && y.DateTo >= date && y.Days.Contains(dayNumber)))
                .OrderBy(x => random)
                .Take(numberOfDriver)
                .ToListAsync();

                // Event
                var eventMessage = new AssignEmployeesEvent()
                {
                    Employees = employees
                        .AsQueryable()
                        .ProjectTo<EmployeeEO>(_mapper.ConfigurationProvider)
                        .ToList(),
                };
                await _publishEndpoint.Publish(eventMessage);
            }
        }
    }
}
