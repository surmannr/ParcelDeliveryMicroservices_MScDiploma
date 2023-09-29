using Common.Paging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeGen.Core.TypeAnnotations;

namespace Common.Filter
{
    [ExportTsClass(OutputDir = "../../../../../frontend/web/parceldelivery-admin-app/src/app/_filters")]
    public abstract class MongoBaseFilter<T> : BaseFilter<T>
    {
        public virtual IAggregateFluent<T> ExecuteOrdering(IAggregateFluent<T> toFilter)
        {
            var builder = Builders<T>.Sort;
            if (!string.IsNullOrEmpty(OrderBy))
            {
                if (OrderAscending)
                {
                    return toFilter.Sort(builder.Ascending(OrderBy));
                }
                else
                {
                    return toFilter.Sort(builder.Descending(OrderBy));
                }
            }
            return toFilter;
        }

        public abstract IAggregateFluent<T> ExecuteFiltering(IAggregateFluent<T> toFilter);
    }
}
