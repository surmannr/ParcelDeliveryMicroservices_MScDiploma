using Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageDelivery.DAL.Entities.Filters
{
    public class VehicleFilter : BaseFilter<Vehicle>
    {
        public string RegistrationNumber { get; set; }
        public string Type { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public DateTime? MinTechnicalInspectionExpirationDate { get; set; }
        public DateTime? MaxTechnicalInspectionExpirationDate { get; set; }
        public int? MinSeatingCapacity { get; set; }
        public int? MaxSeatingCapacity { get; set; }
        public double? Min_MaxInternalSpaceX { get; set; }
        public double? Max_MaxInternalSpaceX { get; set; }
        public double? Min_MaxInternalSpaceY { get; set; }
        public double? Max_MaxInternalSpaceY { get; set; }
        public double? Min_MaxInternalSpaceZ { get; set; }
        public double? Max_MaxInternalSpaceZ { get; set; }
        public double? Min_MaxWeight { get; set; }
        public double? Max_MaxWeight { get; set; }

        public override IQueryable<Vehicle> ExecuteFiltering(IQueryable<Vehicle> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = !string.IsNullOrEmpty(RegistrationNumber) ? query.Where(a => a.RegistrationNumber.Contains(RegistrationNumber)) : query;
            query = !string.IsNullOrEmpty(Type) ? query.Where(a => a.Type.Contains(Type)) : query;

            query = MinYear != null ? query.Where(a => a.Year >= MinYear) : query;
            query = MaxYear != null ? query.Where(a => a.Year <= MaxYear) : query;

            query = MinTechnicalInspectionExpirationDate != null ? query.Where(a => a.TechnicalInspectionExpirationDate >= MinTechnicalInspectionExpirationDate) : query;
            query = MaxTechnicalInspectionExpirationDate != null ? query.Where(a => a.TechnicalInspectionExpirationDate <= MaxTechnicalInspectionExpirationDate) : query;

            query = MinSeatingCapacity != null ? query.Where(a => a.SeatingCapacity >= MinSeatingCapacity) : query;
            query = MaxSeatingCapacity != null ? query.Where(a => a.SeatingCapacity <= MaxSeatingCapacity) : query;

            query = Min_MaxInternalSpaceX != null ? query.Where(a => a.MaxInternalSpaceX >= Min_MaxInternalSpaceX) : query;
            query = Max_MaxInternalSpaceX != null ? query.Where(a => a.MaxInternalSpaceX <= Max_MaxInternalSpaceX) : query;

            query = Min_MaxInternalSpaceY != null ? query.Where(a => a.MaxInternalSpaceY >= Min_MaxInternalSpaceY) : query;
            query = Max_MaxInternalSpaceY != null ? query.Where(a => a.MaxInternalSpaceY <= Max_MaxInternalSpaceY) : query;

            query = Min_MaxInternalSpaceZ != null ? query.Where(a => a.MaxInternalSpaceZ >= Min_MaxInternalSpaceZ) : query;
            query = Max_MaxInternalSpaceZ != null ? query.Where(a => a.MaxInternalSpaceZ <= Max_MaxInternalSpaceZ) : query;

            query = Min_MaxWeight != null ? query.Where(a => a.MaxWeight >= Min_MaxWeight) : query;
            query = Max_MaxWeight != null ? query.Where(a => a.MaxWeight <= Max_MaxWeight) : query;

            return query;
        }
    }
}
