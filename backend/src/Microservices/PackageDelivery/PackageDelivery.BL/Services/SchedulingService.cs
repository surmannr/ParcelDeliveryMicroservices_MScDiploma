using AutoMapper;
using Common.Dto;
using Common.Entity;
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
        public SchedulingService(IParcelPackingAlgorithm algorithm, IMediator mediator, IMapper mapper)
        {
            _algorithm = algorithm;
            _mediator = mediator;
            _mapper = mapper;
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
                    };

                    await _mediator.Send(new AddNewAcceptedShipRequest.Command()
                    {
                        NewAcceptedShipRequest = acceptedShippingRequest,
                    });
                }
            }
        }
    }
}
