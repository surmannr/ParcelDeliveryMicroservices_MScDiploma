using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Algorithms
{
    public class AlgorithmResult
    {
        public List<ResultPair> Results { get; set; }

        public class ResultPair
        {
            public string VehicleId { get; set; }
            public List<string> PackageIds { get; set; }
        }
    }
}
