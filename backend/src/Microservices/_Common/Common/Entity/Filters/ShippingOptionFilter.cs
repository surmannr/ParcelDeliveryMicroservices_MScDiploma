﻿using Common.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Entity.Filters
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public class ShippingOptionFilter : SqlBaseFilter<ShippingOption>
    {
        public string ShippingOptionName { get; set; }
        public double? MinShippingOptionPrice { get; set; }
        public double? MaxShippingOptionPrice { get; set; }

        public override IQueryable<ShippingOption> ExecuteFiltering(IQueryable<ShippingOption> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = MinShippingOptionPrice != null ? query.Where(a => a.Price >= MinShippingOptionPrice) : query;
            query = MaxShippingOptionPrice != null ? query.Where(a => a.Price <= MaxShippingOptionPrice) : query;

            return query;
        }
    }
}
