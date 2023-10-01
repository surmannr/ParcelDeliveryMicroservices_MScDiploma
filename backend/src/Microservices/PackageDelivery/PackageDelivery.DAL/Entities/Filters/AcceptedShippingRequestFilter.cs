using Common.Extension;
using Common.Filter;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using TypeGen.Core.TypeAnnotations;

namespace PackageDelivery.DAL.Entities.Filters
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public class AcceptedShippingRequestFilter : MongoBaseFilter<AcceptedShippingRequest>
    {
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        public bool? IsAssignedToEmployee { get; set; }
        public bool? IsAllPackageTaken { get; set; }

        public override MongoDB.Driver.IAggregateFluent<AcceptedShippingRequest> ExecuteFiltering(MongoDB.Driver.IAggregateFluent<AcceptedShippingRequest> toFilter)
        {
            var builder = Builders<AcceptedShippingRequest>.Filter;
            var filter = builder.Empty;

            if (IsAllPackageTaken != null)
            {
                filter = filter & builder.Eq(x => x.IsAllPackageTaken, IsAllPackageTaken.Value);
            }
            if (IsAssignedToEmployee != null)
            {
                filter = filter & builder.Eq(x => x.IsAssignedToEmployee, IsAssignedToEmployee.Value);
            }
            if (!string.IsNullOrEmpty(EmployeeName))
            {
                filter = filter & builder.Regex(x => x.EmployeeName, BsonRegularExpression.Create(Regex.Escape(EmployeeName)));
            }
            if (!string.IsNullOrEmpty(EmployeeId))
            {
                filter = filter & builder.Regex(x => x.EmployeeId, BsonRegularExpression.Create(Regex.Escape(EmployeeId)));
            }

            return toFilter.Match(filter);
        }
    }
}
