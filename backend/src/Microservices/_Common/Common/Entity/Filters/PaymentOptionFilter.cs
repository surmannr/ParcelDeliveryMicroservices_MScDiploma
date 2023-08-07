using Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity.Filters
{
    public class PaymentOptionFilter : BaseFilter<PaymentOption>
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
