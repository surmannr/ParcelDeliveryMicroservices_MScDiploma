using Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity.Filters
{
    public class PackageFilter : BaseFilter<Package>
    {
        public double? MinSizeX { get; set; }
        public double? MaxSizeX { get; set; }
        public double? MinSizeY { get; set; }
        public double? MaxSizeY { get; set; }
        public double? MinSizeZ { get; set; }
        public double? MaxSizeZ { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public bool? IsFragile { get; set; }

        public override IQueryable<Package> ExecuteFiltering(IQueryable<Package> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = MinSizeX != null ? query.Where(a => a.SizeX >= MinSizeX) : query;
            query = MaxSizeX != null ? query.Where(a => a.SizeX <= MaxSizeX) : query;

            query = MinSizeY != null ? query.Where(a => a.SizeY >= MinSizeY) : query;
            query = MaxSizeY != null ? query.Where(a => a.SizeY <= MaxSizeY) : query;

            query = MinSizeZ != null ? query.Where(a => a.SizeZ >= MinSizeZ) : query;
            query = MaxSizeZ != null ? query.Where(a => a.SizeZ <= MaxSizeZ) : query;

            query = MinWeight != null ? query.Where(a => a.Weight >= MinWeight) : query;
            query = MaxWeight != null ? query.Where(a => a.Weight <= MaxWeight) : query;

            query = IsFragile != null ? query.Where(a => a.IsFragile == IsFragile) : query;

            return query;
        }
    }
}
