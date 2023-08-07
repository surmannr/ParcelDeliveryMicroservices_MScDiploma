using Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filter
{
    public static class FilteringExtension
    {
        public static IQueryable<T> ExecuteFilterAndOrder<T>(this IQueryable<T> list, BaseFilter<T> parameter)
        {
            var filteredList = parameter.ExecuteFiltering(list);
            return parameter.ExecuteOrdering(filteredList);
        }
    }
}
