using Common.Extension;
using Common.Filter;

namespace Common.Entity.Filters
{
    public class ShippingRequestFilter : SqlBaseFilter<ShippingRequest>
    {
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

        public override IQueryable<ShippingRequest> ExecuteFiltering(IQueryable<ShippingRequest> toFilter)
        {
            var query = toFilter.AsQueryable();

            // Names
            query = !string.IsNullOrEmpty(ShippingOptionName) ? query.Where(a => a.ShippingOption.Name.Contains(ShippingOptionName)) : query;
            query = !string.IsNullOrEmpty(PaymentOptionName) ? query.Where(a => a.PaymentOption.Name.Contains(PaymentOptionName)) : query;
            query = !string.IsNullOrEmpty(StatusName) ? query.Where(a => a.Status.GetDisplayName().Contains(StatusName)) : query;

            // Bool values
            query = IsExpress != null ? query.Where(a => a.IsExpress == IsExpress) : query;
            query = IsFinished != null ? query.Where(a => a.IsFinished == IsFinished) : query;

            // DateTime values
            query = MinDateOfDispatch != null ? query.Where(a => a.DateOfDispatch >= MinDateOfDispatch) : query;
            query = MaxDateOfDispatch != null ? query.Where(a => a.DateOfDispatch <= MaxDateOfDispatch) : query;

            // Address values
            query = !string.IsNullOrEmpty(Street) ? query.Where(a => a.AddressFrom.Street.Contains(Street) || a.AddressTo.Street.Contains(Street)) : query;
            query = !string.IsNullOrEmpty(City) ? query.Where(a => a.AddressFrom.Street.Contains(City) || a.AddressTo.Street.Contains(City)) : query;
            query = !string.IsNullOrEmpty(Country) ? query.Where(a => a.AddressFrom.Street.Contains(Country) || a.AddressTo.Street.Contains(Country)) : query;
            query = ZipCode != null ? query.Where(a => a.AddressFrom.ZipCode.ToString().Contains(ZipCode.ToString()) || a.AddressTo.ZipCode.ToString().Contains(ZipCode.ToString())) : query;

            return query;
        }
    }
}
