using Common.Extension;
using Common.Filter;

namespace PackageDelivery.DAL.Entities.Filters
{
    public class AcceptedShippingRequestFilter : BaseFilter<AcceptedShippingRequest>
    {
        public string EmployeeName { get; set; }
        public bool? IsAllPackageTaken { get; set; }

        // ShippingRequest
        public string StatusName { get; set; }
        public string ShippingOptionName { get; set; }
        public string PaymentOptionName { get; set; }

        public DateTime? MinDateOfDispatch { get; set; }
        public DateTime? MaxDateOfDispatch { get; set; }

        public bool? IsExpress { get; set; }
        public bool? IsFinished { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public int? ZipCode { get; set; }
        public string Country { get; set; }

        public override IQueryable<AcceptedShippingRequest> ExecuteFiltering(IQueryable<AcceptedShippingRequest> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = IsAllPackageTaken != null ? query.Where(a => a.IsAllPackageTaken == IsAllPackageTaken) : query;
            query = !string.IsNullOrEmpty(EmployeeName) ? query.Where(a => a.EmployeeName.Contains(EmployeeName)) : query;

            // ShippingRequest
            query = !string.IsNullOrEmpty(ShippingOptionName) ? query.Where(a => a.Shipping.ShippingOption.Name.Contains(ShippingOptionName)) : query;
            query = !string.IsNullOrEmpty(PaymentOptionName) ? query.Where(a => a.Shipping.PaymentOption.Name.Contains(PaymentOptionName)) : query;
            query = !string.IsNullOrEmpty(StatusName) ? query.Where(a => a.Shipping.Status.GetDisplayName().Contains(StatusName)) : query;

            query = IsExpress != null ? query.Where(a => a.Shipping.IsExpress == IsExpress) : query;
            query = IsFinished != null ? query.Where(a => a.Shipping.IsFinished == IsFinished) : query;

            query = MinDateOfDispatch != null ? query.Where(a => a.Shipping.DateOfDispatch >= MinDateOfDispatch) : query;
            query = MaxDateOfDispatch != null ? query.Where(a => a.Shipping.DateOfDispatch <= MaxDateOfDispatch) : query;

            query = !string.IsNullOrEmpty(Street) ? query.Where(a => a.Shipping.AddressFrom.Street.Contains(Street) || a.Shipping.AddressTo.Street.Contains(Street)) : query;
            query = !string.IsNullOrEmpty(City) ? query.Where(a => a.Shipping.AddressFrom.Street.Contains(City) || a.Shipping.AddressTo.Street.Contains(City)) : query;
            query = !string.IsNullOrEmpty(Country) ? query.Where(a => a.Shipping.AddressFrom.Street.Contains(Country) || a.Shipping.AddressTo.Street.Contains(Country)) : query;
            query = ZipCode != null ? query.Where(a => a.Shipping.AddressFrom.ZipCode.ToString().Contains(ZipCode.ToString()) || a.Shipping.AddressTo.ZipCode.ToString().Contains(ZipCode.ToString())) : query;

            return query;
        }
    }
}
