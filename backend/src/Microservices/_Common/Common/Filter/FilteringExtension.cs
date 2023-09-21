using MongoDB.Driver;

namespace Common.Filter
{
    public static class FilteringExtension
    {
        public static IQueryable<T> ExecuteFilterAndOrder<T>(this IQueryable<T> list, SqlBaseFilter<T> parameter)
        {
            var filteredList = parameter.ExecuteFiltering(list);
            return parameter.ExecuteOrdering(filteredList);
        }

        public static IAggregateFluent<T> ExecuteFilterAndOrder<T>(this IMongoCollection<T> list, MongoBaseFilter<T> parameter)
        {
            var filteredList = parameter.ExecuteFiltering(list.Aggregate());
            return parameter.ExecuteOrdering(filteredList);
        }
    }
}
