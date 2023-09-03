using Common.Filter;

namespace PackageDelivery.DAL.Entities.Filters
{
    public class VehicleUsageFilter : BaseFilter<VehicleUsage>
    {
        // VehicleUsage
        public DateTime? MinDateFrom { get; set; }
        public DateTime? MaxDateFrom { get; set; }
        public DateTime? MinDateTo { get; set; }
        public DateTime? MaxDateTo { get; set; }
        public string Note { get; set; }

        // Vehicle
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

        public override IQueryable<VehicleUsage> ExecuteFiltering(IQueryable<VehicleUsage> toFilter)
        {
            var query = toFilter.AsQueryable();

            // VehicleUsage
            query = MinDateFrom != null ? query.Where(a => a.DateFrom >= MinDateFrom) : query;
            query = MaxDateFrom != null ? query.Where(a => a.DateFrom <= MaxDateFrom) : query;

            query = MinDateTo != null ? query.Where(a => a.DateTo >= MinDateTo) : query;
            query = MaxDateTo != null ? query.Where(a => a.DateTo <= MaxDateTo) : query;

            query = !string.IsNullOrEmpty(Note) ? query.Where(a => a.Note.Contains(Note)) : query;

            // Vehicle
            query = !string.IsNullOrEmpty(RegistrationNumber) ? query.Where(a => a.Vehicle.RegistrationNumber.Contains(RegistrationNumber)) : query;
            query = !string.IsNullOrEmpty(Type) ? query.Where(a => a.Vehicle.Type.Contains(Type)) : query;

            query = MinYear != null ? query.Where(a => a.Vehicle.Year >= MinYear) : query;
            query = MaxYear != null ? query.Where(a => a.Vehicle.Year <= MaxYear) : query;

            query = MinTechnicalInspectionExpirationDate != null ? query.Where(a => a.Vehicle.TechnicalInspectionExpirationDate >= MinTechnicalInspectionExpirationDate) : query;
            query = MaxTechnicalInspectionExpirationDate != null ? query.Where(a => a.Vehicle.TechnicalInspectionExpirationDate <= MaxTechnicalInspectionExpirationDate) : query;

            query = MinSeatingCapacity != null ? query.Where(a => a.Vehicle.SeatingCapacity >= MinSeatingCapacity) : query;
            query = MaxSeatingCapacity != null ? query.Where(a => a.Vehicle.SeatingCapacity <= MaxSeatingCapacity) : query;

            query = Min_MaxInternalSpaceX != null ? query.Where(a => a.Vehicle.MaxInternalSpaceX >= Min_MaxInternalSpaceX) : query;
            query = Max_MaxInternalSpaceX != null ? query.Where(a => a.Vehicle.MaxInternalSpaceX <= Max_MaxInternalSpaceX) : query;

            query = Min_MaxInternalSpaceY != null ? query.Where(a => a.Vehicle.MaxInternalSpaceY >= Min_MaxInternalSpaceY) : query;
            query = Max_MaxInternalSpaceY != null ? query.Where(a => a.Vehicle.MaxInternalSpaceY <= Max_MaxInternalSpaceY) : query;

            query = Min_MaxInternalSpaceZ != null ? query.Where(a => a.Vehicle.MaxInternalSpaceZ >= Min_MaxInternalSpaceZ) : query;
            query = Max_MaxInternalSpaceZ != null ? query.Where(a => a.Vehicle.MaxInternalSpaceZ <= Max_MaxInternalSpaceZ) : query;

            query = Min_MaxWeight != null ? query.Where(a => a.Vehicle.MaxWeight >= Min_MaxWeight) : query;
            query = Max_MaxWeight != null ? query.Where(a => a.Vehicle.MaxWeight <= Max_MaxWeight) : query;

            return query;
        }
    }
}
