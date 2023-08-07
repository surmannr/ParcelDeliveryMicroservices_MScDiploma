using Common.Extension;
using Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity.Filters
{
    public class BillingFilter : BaseFilter<Billing>
    {
        public double? MinTotalDistance { get; set; }
        public double? MaxTotalDistance { get; set; }
        public double? MinTotalAmount { get; set; }
        public double? MaxTotalAmount { get; set; }

        public string Name { get; set; }
        public string StatusName { get; set; }
        public string CurrencyName { get; set; }
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

        public override IQueryable<Billing> ExecuteFiltering(IQueryable<Billing> toFilter)
        {
            var query = toFilter.AsQueryable();

            // Names
            query = !string.IsNullOrEmpty(Name) ? query.Where(a => a.Name.Contains(Name)) : query;
            query = !string.IsNullOrEmpty(CurrencyName) ? query.Where(a => a.Currency.Name.Contains(CurrencyName)) : query;
            query = !string.IsNullOrEmpty(ShippingOptionName) ? query.Where(a => a.ShippingRequest.ShippingOption.Name.Contains(ShippingOptionName)) : query;
            query = !string.IsNullOrEmpty(PaymentOptionName) ? query.Where(a => a.ShippingRequest.PaymentOption.Name.Contains(PaymentOptionName)) : query;
            query = !string.IsNullOrEmpty(StatusName) ? query.Where(a => a.ShippingRequest.Status.GetDisplayName().Contains(StatusName)) : query;

            // Number values
            query = MinTotalDistance != null ? query.Where(a => a.TotalDistance >= MinTotalDistance) : query;
            query = MaxTotalDistance != null ? query.Where(a => a.TotalDistance <= MaxTotalDistance) : query;
            query = MinTotalAmount != null ? query.Where(a => a.TotalAmount >= MinTotalAmount) : query;
            query = MaxTotalAmount != null ? query.Where(a => a.TotalAmount <= MaxTotalAmount) : query;

            // Bool values
            query = IsExpress != null ? query.Where(a => a.ShippingRequest.IsExpress == IsExpress) : query;
            query = IsFinished != null ? query.Where(a => a.ShippingRequest.IsFinished == IsFinished) : query;

            // DateTime values
            query = MinDateOfDispatch != null ? query.Where(a => a.ShippingRequest.DateOfDispatch >= MinDateOfDispatch) : query;
            query = MaxDateOfDispatch != null ? query.Where(a => a.ShippingRequest.DateOfDispatch <= MaxDateOfDispatch) : query;

            // Address values
            query = !string.IsNullOrEmpty(Street) ? query.Where(a => a.ShippingRequest.AddressFrom.Street.Contains(Street) || a.ShippingRequest.AddressTo.Street.Contains(Street)) : query;
            query = !string.IsNullOrEmpty(City) ? query.Where(a => a.ShippingRequest.AddressFrom.Street.Contains(City) || a.ShippingRequest.AddressTo.Street.Contains(City)) : query;
            query = !string.IsNullOrEmpty(Country) ? query.Where(a => a.ShippingRequest.AddressFrom.Street.Contains(Country) || a.ShippingRequest.AddressTo.Street.Contains(Country)) : query;
            query = ZipCode != null ? query.Where(a => a.ShippingRequest.AddressFrom.ZipCode.ToString().Contains(ZipCode.ToString()) || a.ShippingRequest.AddressTo.ZipCode.ToString().Contains(ZipCode.ToString())) : query;

            return query;
        }
    }
}
