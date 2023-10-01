using Common.Filter;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using TypeGen.Core.TypeAnnotations;

namespace PackageDelivery.DAL.Entities.Filters
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public class VehicleUsageFilter : MongoBaseFilter<VehicleUsage>
    {
        // VehicleUsage
        public DateTime? MinDateFrom { get; set; }
        public DateTime? MaxDateFrom { get; set; }
        public DateTime? MinDateTo { get; set; }
        public DateTime? MaxDateTo { get; set; }
        public string Note { get; set; }
        public string EmployeeId { get; set; }

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

        public override IAggregateFluent<VehicleUsage> ExecuteFiltering(IAggregateFluent<VehicleUsage> toFilter)
        {
            var builder = Builders<VehicleUsage>.Filter;
            var filter = builder.Empty;

            // VehicleUsage
            if (MinDateFrom != null)
            {
                filter = filter & builder.Gte(x => x.DateFrom, MinDateFrom.Value);
            }
            if (MaxDateFrom != null)
            {
                filter = filter & builder.Lte(x => x.DateFrom, MaxDateFrom.Value);
            }

            if (MinDateTo != null)
            {
                filter = filter & builder.Gte(x => x.DateTo, MinDateTo.Value);
            }
            if (MaxDateTo != null)
            {
                filter = filter & builder.Lte(x => x.DateTo, MaxDateTo.Value);
            }

            if (!string.IsNullOrEmpty(Note))
            {
                filter = filter & builder.Regex(x => x.Note, BsonRegularExpression.Create(Regex.Escape(Note)));
            }
            if (!string.IsNullOrEmpty(EmployeeId))
            {
                filter = filter & builder.Regex(x => x.EmployeeId, BsonRegularExpression.Create(Regex.Escape(EmployeeId)));
            }

            // Vehicle
            if (!string.IsNullOrEmpty(RegistrationNumber))
            {
                filter = filter & builder.Regex(x => x.Vehicle.RegistrationNumber, BsonRegularExpression.Create(Regex.Escape(RegistrationNumber)));
            }
            if (!string.IsNullOrEmpty(Type))
            {
                filter = filter & builder.Regex(x => x.Vehicle.Type, BsonRegularExpression.Create(Regex.Escape(Type)));
            }

            if (MinYear != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.Year, MinYear.Value);
            }
            if (MaxYear != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.Year, MaxYear.Value);
            }

            if (MinTechnicalInspectionExpirationDate != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.TechnicalInspectionExpirationDate, MinTechnicalInspectionExpirationDate.Value);
            }
            if (MaxTechnicalInspectionExpirationDate != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.TechnicalInspectionExpirationDate, MaxTechnicalInspectionExpirationDate.Value);
            }

            if (MinSeatingCapacity != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.SeatingCapacity, MinSeatingCapacity.Value);
            }
            if (MaxSeatingCapacity != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.SeatingCapacity, MaxSeatingCapacity.Value);
            }

            if (Min_MaxInternalSpaceX != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.MaxInternalSpaceX, Min_MaxInternalSpaceX.Value);
            }
            if (Max_MaxInternalSpaceX != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.MaxInternalSpaceX, Max_MaxInternalSpaceX.Value);
            }

            if (Min_MaxInternalSpaceY != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.MaxInternalSpaceY, Min_MaxInternalSpaceY.Value);
            }
            if (Max_MaxInternalSpaceY != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.MaxInternalSpaceY, Max_MaxInternalSpaceY.Value);
            }

            if (Min_MaxInternalSpaceZ != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.MaxInternalSpaceZ, Min_MaxInternalSpaceZ.Value);
            }
            if (Max_MaxInternalSpaceZ != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.MaxInternalSpaceZ, Max_MaxInternalSpaceZ.Value);
            }

            if (Min_MaxWeight != null)
            {
                filter = filter & builder.Gte(x => x.Vehicle.MaxWeight, Min_MaxWeight.Value);
            }
            if (Max_MaxWeight != null)
            {
                filter = filter & builder.Lte(x => x.Vehicle.MaxWeight, Max_MaxWeight.Value);
            }

            return toFilter.Match(filter);
        }
    }
}
