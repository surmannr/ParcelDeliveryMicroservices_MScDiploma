using Common.Filter;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PackageDelivery.DAL.Entities.Filters
{
    public class VehicleFilter : MongoBaseFilter<Vehicle>
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

        public override MongoDB.Driver.IAggregateFluent<Vehicle> ExecuteFiltering(MongoDB.Driver.IAggregateFluent<Vehicle> toFilter)
        {
            var builder = Builders<Vehicle>.Filter;
            var filter = builder.Empty;

            if (!string.IsNullOrEmpty(RegistrationNumber))
            {
                filter = filter & builder.Regex(x => x.RegistrationNumber, BsonRegularExpression.Create(Regex.Escape(RegistrationNumber)));
            }
            if (!string.IsNullOrEmpty(Type))
            {
                filter = filter & builder.Regex(x => x.Type, BsonRegularExpression.Create(Regex.Escape(Type)));
            }

            if (MinYear != null)
            {
                filter = filter & builder.Gte(x => x.Year, MinYear.Value);
            }
            if (MaxYear != null)
            {
                filter = filter & builder.Lte(x => x.Year, MaxYear.Value);
            }

            if (MinTechnicalInspectionExpirationDate != null)
            {
                filter = filter & builder.Gte(x => x.TechnicalInspectionExpirationDate, MinTechnicalInspectionExpirationDate.Value);
            }
            if (MaxTechnicalInspectionExpirationDate != null)
            {
                filter = filter & builder.Lte(x => x.TechnicalInspectionExpirationDate, MaxTechnicalInspectionExpirationDate.Value);
            }

            if (MinSeatingCapacity != null)
            {
                filter = filter & builder.Gte(x => x.SeatingCapacity, MinSeatingCapacity.Value);
            }
            if (MaxSeatingCapacity != null)
            {
                filter = filter & builder.Lte(x => x.SeatingCapacity, MaxSeatingCapacity.Value);
            }

            if (Min_MaxInternalSpaceX != null)
            {
                filter = filter & builder.Gte(x => x.MaxInternalSpaceX, Min_MaxInternalSpaceX.Value);
            }
            if (Max_MaxInternalSpaceX != null)
            {
                filter = filter & builder.Lte(x => x.MaxInternalSpaceX, Max_MaxInternalSpaceX.Value);
            }

            if (Min_MaxInternalSpaceY != null)
            {
                filter = filter & builder.Gte(x => x.MaxInternalSpaceY, Min_MaxInternalSpaceY.Value);
            }
            if (Max_MaxInternalSpaceY != null)
            {
                filter = filter & builder.Lte(x => x.MaxInternalSpaceY, Max_MaxInternalSpaceY.Value);
            }

            if (Min_MaxInternalSpaceZ != null)
            {
                filter = filter & builder.Gte(x => x.MaxInternalSpaceZ, Min_MaxInternalSpaceZ.Value);
            }
            if (Max_MaxInternalSpaceZ != null)
            {
                filter = filter & builder.Lte(x => x.MaxInternalSpaceZ, Max_MaxInternalSpaceZ.Value);
            }

            if (Min_MaxWeight != null)
            {
                filter = filter & builder.Gte(x => x.MaxWeight, Min_MaxWeight.Value);
            }
            if (Max_MaxWeight != null)
            {
                filter = filter & builder.Lte(x => x.MaxWeight, Max_MaxWeight.Value);
            }

            return toFilter.Match(filter);
        }
    }
}
