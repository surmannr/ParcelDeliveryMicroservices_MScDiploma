using Common.Dto;
using MediatR;
using PackageDelivery.BL.Dto;
using PackageDelivery.BL.Features._ShippingRequest.Queries;
using PackageDelivery.BL.Features._Vehicle.Queries;
using PackageDelivery.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PackageDelivery.BL.Algorithms.AlgorithmResult;

namespace PackageDelivery.BL.Algorithms
{
    // Csomagok besorolasa kulonbozo jarmuvekbe
    public class ParcelPackingAlgorithm : IParcelPackingAlgorithm
    {
        private readonly IMediator _mediator;

        List<string> vehicleIdsWithFullStorage = new();
        VehicleDto selectedVehicle = new();
        List<VehicleDto> vehicles = new();

        public ParcelPackingAlgorithm(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<AlgorithmResult> Execute(DateTime date)
        {
            // Járművek lekérése
            var pagedVehicleResult = await _mediator.Send(new GetAllVehicles.Query()
            {
                PageSize = 0,
            });
            vehicles = (List<VehicleDto>)pagedVehicleResult.Data;

            // Random járművet kiválasztunk
            SelectRandomVehicle();

            // A dátum szerinti csomagfeladások lekérdezése
            var shippingRequests = await _mediator.Send(new GetAllShippingRequests.Query()
            {
                PageSize = 0,
                MinDateOfDispatch = date.AddDays(-2),
                MaxDateOfDispatch = date.AddDays(1),
                IsFinished = false
            });

            List<ResultPair> results = new();

            // Végigmegyünk a csomagfeladásokon és az algoritmus eredményéhez mentjük
            foreach (var shippingReq in shippingRequests.Data)
            {
                var partialResults = PackageSortingToVehicle(shippingReq);

                results.AddRange(partialResults);
            }

            return new AlgorithmResult() 
            { 
                Results= results 
            };
        }

        private List<ResultPair> PackageSortingToVehicle(ShippingRequestDto shipReq)
        {
            List<ResultPair> partialResults = new();

            foreach (var package in shipReq.Packages)
            {
                var diffX = selectedVehicle.MaxInternalSpaceX - package.SizeX;
                var diffY = selectedVehicle.MaxInternalSpaceY - package.SizeY;
                var diffZ = selectedVehicle.MaxInternalSpaceZ - package.SizeZ;

                if (diffX <= 0 || diffY <= 0 || diffZ <= 0)
                {
                    vehicleIdsWithFullStorage.Add(selectedVehicle.Id);
                    SelectRandomVehicle();
                }

                selectedVehicle.MaxInternalSpaceX -= package.SizeX;
                selectedVehicle.MaxInternalSpaceY -= package.SizeY;
                selectedVehicle.MaxInternalSpaceZ -= package.SizeZ;

                partialResults.Add(
                    new ResultPair()
                    {
                        Vehicle = selectedVehicle,
                        VehicleId= selectedVehicle.Id,
                        Package = package,
                        ShippingRequest = shipReq,
                    });
            }

            return partialResults;
        }

        private void SelectRandomVehicle()
        {
            var rand = new Random();
            selectedVehicle = vehicles
                .Where(x => vehicleIdsWithFullStorage.Any(y => y != x.Id))
                .ElementAt(rand.Next(vehicles.Count()));
        }
    }
}
