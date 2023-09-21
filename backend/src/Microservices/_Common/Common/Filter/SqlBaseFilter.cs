using System.Linq.Dynamic.Core;

namespace Common.Filter
{
    public abstract class SqlBaseFilter<T> : BaseFilter<T>
    {
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
