using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageDelivery.BL.Algorithms
{
    public interface IParcelPackingAlgorithm
    {
        public Task<AlgorithmResult> Execute(DateTime date);
    }
}
