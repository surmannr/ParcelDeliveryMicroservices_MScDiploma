﻿using Common.Filter;

namespace Common.Entity.Filters
{
    public class CurrencyFilter : SqlBaseFilter<Currency>
    {
        public string CurrencyName { get; set; }

        public override IQueryable<Currency> ExecuteFiltering(IQueryable<Currency> toFilter)
        {
            var query = toFilter.AsQueryable();

            query = !string.IsNullOrEmpty(CurrencyName) ? query.Where(a => a.Name.Contains(CurrencyName)) : query;

            return query;
        }
    }
}
