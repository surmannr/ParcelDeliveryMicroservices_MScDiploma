using Common.Extension;
using Common.Filter;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Entity.Filters
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public class ShippingRequestMongoFilter : MongoBaseFilter<ShippingRequest>
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

        public override IAggregateFluent<ShippingRequest> ExecuteFiltering(IAggregateFluent<ShippingRequest> toFilter)
        {
            var builder = Builders<ShippingRequest>.Filter;
            var filter = builder.Empty;

            // Names
            if (!string.IsNullOrEmpty(ShippingOptionName))
            {
                filter = filter & builder.Regex(x => x.ShippingOption.Name, BsonRegularExpression.Create(Regex.Escape(ShippingOptionName)));
            }
            if (!string.IsNullOrEmpty(PaymentOptionName))
            {
                filter = filter & builder.Regex(x => x.PaymentOption.Name, BsonRegularExpression.Create(Regex.Escape(PaymentOptionName)));
            }
            if (!string.IsNullOrEmpty(StatusName))
            {
                filter = filter & builder.Regex(x => x.Status.GetDisplayName(), BsonRegularExpression.Create(Regex.Escape(StatusName)));
            }

            // Bool values
            if (IsExpress != null)
            {
                filter = filter & builder.Eq(x => x.IsExpress, IsExpress.Value);
            }
            if (IsFinished != null)
            {
                filter = filter & builder.Eq(x => x.IsFinished, IsFinished.Value);
            }

            // DateTime values
            if (MinDateOfDispatch != null)
            {
                filter = filter & builder.Gte(x => x.DateOfDispatch, MinDateOfDispatch.Value);
            }
            if (MaxDateOfDispatch != null)
            {
                filter = filter & builder.Lte(x => x.DateOfDispatch, MaxDateOfDispatch.Value);
            }

            // Address values
            if (!string.IsNullOrEmpty(Street))
            {
                filter = filter & builder.Regex(x => x.AddressFrom.Street, BsonRegularExpression.Create(Regex.Escape(Street)));
                filter = filter & builder.Regex(x => x.AddressTo.Street, BsonRegularExpression.Create(Regex.Escape(Street)));
            }

            if (!string.IsNullOrEmpty(City))
            {
                filter = filter & builder.Regex(x => x.AddressFrom.City, BsonRegularExpression.Create(Regex.Escape(City)));
                filter = filter & builder.Regex(x => x.AddressTo.City, BsonRegularExpression.Create(Regex.Escape(City)));
            }

            if (!string.IsNullOrEmpty(Country))
            {
                filter = filter & builder.Regex(x => x.AddressFrom.Country, BsonRegularExpression.Create(Regex.Escape(Country)));
                filter = filter & builder.Regex(x => x.AddressTo.Country, BsonRegularExpression.Create(Regex.Escape(Country)));
            }

            if (ZipCode != null)
            {
                filter = filter & builder.Eq(x => x.AddressFrom.ZipCode, ZipCode.Value);
                filter = filter & builder.Eq(x => x.AddressTo.ZipCode, ZipCode.Value);
            }

            return toFilter.Match(filter);
        }
    }
}
