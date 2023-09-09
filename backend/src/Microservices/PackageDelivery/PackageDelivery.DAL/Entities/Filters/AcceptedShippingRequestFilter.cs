using Common.Extension;
using Common.Filter;

namespace PackageDelivery.DAL.Entities.Filters
{
    public class AcceptedShippingRequestFilter : BaseFilter<AcceptedShippingRequest>
    {
        public string EmployeeName { get; set; }
        public bool? IsAllPackageTaken { get; set; }

        public override IQueryable<AcceptedShippingRequest> ExecuteFiltering(IQueryable<AcceptedShippingRequest> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = IsAllPackageTaken != null ? query.Where(a => a.IsAllPackageTaken == IsAllPackageTaken) : query;
            query = !string.IsNullOrEmpty(EmployeeName) ? query.Where(a => a.EmployeeName.Contains(EmployeeName)) : query;

            return query;
        }
    }
}
