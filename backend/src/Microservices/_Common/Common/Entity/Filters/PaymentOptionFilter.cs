using Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Entity.Filters
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public class PaymentOptionFilter : SqlBaseFilter<PaymentOption>
    {
        public string PaymentOptionName { get; set; }

        public override IQueryable<PaymentOption> ExecuteFiltering(IQueryable<PaymentOption> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = !string.IsNullOrEmpty(PaymentOptionName) ? query.Where(a => a.Name.Contains(PaymentOptionName)) : query;

            return query;
        }
    }
}
