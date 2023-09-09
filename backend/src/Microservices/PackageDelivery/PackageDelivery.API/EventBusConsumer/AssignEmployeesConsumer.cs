using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using PackageDelivery.BL.Features._AcceptedShipRequest.Commands;
using PackageDelivery.BL.Features._AcceptedShipRequest.Queries;

namespace PackageDelivery.API.EventBusConsumer
{
    public class AssignEmployeesConsumer : IConsumer<AssignEmployeesEvent>
    {
        private readonly IMediator _mediator;
        public AssignEmployeesConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AssignEmployeesEvent> context)
        {
            var acceptedShipRequests = await _mediator.Send(new GetAllAcceptedShipRequests.Query()
            {
                IsAllPackageTaken = false,
                PageSize = 0,
            });

            var employees = context.Message.Employees;

            for (int i = 0; i < acceptedShipRequests.Data.Count(); i++)
            {
                var employee = employees.ElementAt(i % employees.Count());
                acceptedShipRequests.Data.ElementAt(i).EmployeeId = employee.Id; 
                acceptedShipRequests.Data.ElementAt(i).EmployeeEmail = employee.Email; 
                acceptedShipRequests.Data.ElementAt(i).EmployeeName = string.IsNullOrEmpty(employee.NamePrefix)
                    ? $"{employee.FirstName} {employee.LastName}"
                    : $"{employee.NamePrefix} {employee.FirstName} {employee.LastName}";

                await _mediator.Send(new EditAcceptedShipRequest.Command()
                {
                    ModifiedAcceptedShipRequest = acceptedShipRequests.Data.ElementAt(i)
                });
            }
        }
    }
}
