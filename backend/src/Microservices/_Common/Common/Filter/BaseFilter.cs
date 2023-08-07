using Common.Paging;
using System.Linq.Dynamic.Core;

namespace Common.Filter
{
    public abstract class BaseFilter<T> : PagingParameter
    {
        public string OrderBy { get; set; }
        public bool OrderAscending { get; set; } = true;

        public virtual IQueryable<T> ExecuteOrdering(IQueryable<T> toFilter)
        {
            return !string.IsNullOrEmpty(OrderBy)
                ? OrderAscending
                    ? toFilter.OrderBy(OrderBy)
                    : toFilter.OrderBy(OrderBy + " desc")
                : toFilter;
        }

        public abstract IQueryable<T> ExecuteFiltering(IQueryable<T> toFilter);
    }
}
