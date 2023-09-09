using Common.Dto;
using PackageDelivery.BL.Dto;

namespace PackageDelivery.BL.Algorithms
{
    public class AlgorithmResult
    {
        public List<ResultPair> Results { get; set; }

        public class ResultPair
        {
            public string VehicleId { get; set; }
            public VehicleDto Vehicle { get; set; }
            public PackageDto Package { get; set; }
            public ShippingRequestDto ShippingRequest { get; set; }
        }
    }
}
