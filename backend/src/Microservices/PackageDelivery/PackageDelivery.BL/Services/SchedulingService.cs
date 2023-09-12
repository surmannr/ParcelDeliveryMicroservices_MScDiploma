using AutoMapper;
using Common.Dto;
using Common.Entity;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using PackageDelivery.BL.Algorithms;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._AcceptedShipRequest.Commands;
using PackageDelivery.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Services
{
    public class SchedulingService : ISchedulingService
    {
        private readonly IParcelPackingAlgorithm _algorithm;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public SchedulingService(IParcelPackingAlgorithm algorithm, IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _algorithm = algorithm;
            _mediator = mediator;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Schedule()
        {
            var date = DateTime.Now;

            await ScheduleParcelDelivery(date);
        }

        private async Task ScheduleParcelDelivery(DateTime date)
        {
            var result = await _algorithm.Execute(date);

            if (result != null && result.Results.Any())
            {
                var groupByResult = result.Results.GroupBy(x => x.VehicleId);

                foreach (var groupedVehicle in groupByResult)
                {
                    List<PackageDto> packages = new();
                    List<ShippingRequestDto> shippingRequests = new();
                    VehicleDto vehicle = null;
                    foreach (var group in groupedVehicle)
                    {
                        packages.Add(group.Package);
                        shippingRequests.Add(group.ShippingRequest);
                        vehicle ??= group.Vehicle;
                    }

                    var acceptedShippingRequest = new AcceptedShippingRequestDto()
                    {
                        Vehicle = vehicle,
                        Packages = packages,
                        ShippingRequests = shippingRequests,
                        IsAllPackageTaken = false,
                        IsAssignedToEmployee = false,
                    };

                    await _mediator.Send(new AddNewAcceptedShipRequest.Command()
                    {
                        NewAcceptedShipRequest = acceptedShippingRequest,
                    });
                }

                // Event
                var eventMessage = new AlgorithmExecutedEvent()
                {
                    NumberOfDriversNeed = groupByResult.Count(),
                    Date = date,
                    DayNumber = (int)(date.DayOfWeek + 6) % 7
                };
                await _publishEndpoint.Publish(eventMessage);
            }
        }
    }
}
