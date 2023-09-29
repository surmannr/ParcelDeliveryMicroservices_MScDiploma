using System.Linq.Dynamic.Core;
using TypeGen.Core.TypeAnnotations;

namespace Common.Filter
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
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
