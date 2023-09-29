using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Entity
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_models")]
    public class Billing
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double TotalDistance { get; set; }
        public double TotalAmount { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        [BsonIgnoreIfNull]
        public ShippingRequest ShippingRequest { get; set; }
    }
}
