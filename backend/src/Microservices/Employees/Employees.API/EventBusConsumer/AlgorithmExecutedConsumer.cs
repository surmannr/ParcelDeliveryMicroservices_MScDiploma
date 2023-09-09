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
                var employees = await _dbContext.Users
                    .Include(x => x.Timesheets)
                    .Where(x => x.Timesheets.Any(y => y.DateFrom <= context.Message.Date && y.DateTo >= context.Message.Date && y.DaysArray.Contains(context.Message.DayNumber)))
                    .OrderBy(x => rnd.Next())
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
