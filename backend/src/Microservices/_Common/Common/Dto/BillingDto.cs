using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Dto
{
    [ExportTsInterface(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_dtos")]
    public class BillingDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double TotalDistance { get; set; }
        public double TotalAmount { get; set; }

        public CurrencyDto Currency { get; set; }
    }
}
