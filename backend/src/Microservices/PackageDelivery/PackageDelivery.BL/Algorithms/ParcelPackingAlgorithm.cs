using MediatR;
using PackageDelivery.BL.Features._ShippingRequest.Queries;
using PackageDelivery.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Algorithms
{
    // Csomagok besorolasa kulonbozo jarmuvekbe
    public class ParcelPackingAlgorithm : IParcelPackingAlgorithm
    {
        private readonly IMediator _mediator;

        public ParcelPackingAlgorithm(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<AlgorithmResult> Execute(DateTime date)
        {
            var shippingRequests = await _mediator.Send(new GetAllShippingRequests.Query()
            {

            });

            throw new Exception();
        }
    }
}
