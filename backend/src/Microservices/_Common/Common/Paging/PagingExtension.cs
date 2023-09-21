using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection.Metadata;

namespace Common.Paging
{
    public static class PagingExtension
    {
        private static readonly int maxPageSize = 100;
        public static async Task<PagedResponse<T>> ToPagedListAsync<T>(this IQueryable<T> list, PagingParameter parameter)
        {
            ValidatePagingParameter(parameter);

            PagedResponse<T> result = new PagedResponse<T>()
            {
                TotalCount = await list.CountAsync(),
                TotalPages = parameter.PageSize != 0
                    ? (await list.CountAsync() + parameter.PageSize - 1) / parameter.PageSize
                    : 1,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
                Data = parameter.PageSize != 0 
                    ? await list.Skip(parameter.PageSize * (parameter.PageNumber - 1)).Take(parameter.PageSize).ToListAsync()
                    : await list.ToListAsync(),
            };

            return result;
        }

        public static async Task<PagedResponse<T>> ToPagedListAsync<T>(this IAggregateFluent<T> list, PagingParameter parameter)
        {
            ValidatePagingParameter(parameter);
            var count = list.Count().FirstOrDefault()?.Count ?? 0;
            PagedResponse<T> result = new PagedResponse<T>()
            {
                TotalCount = ((int)count),
                TotalPages = parameter.PageSize != 0
                    ? (((int)count) + parameter.PageSize - 1) / parameter.PageSize
                    : 1,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
                Data = parameter.PageSize != 0
                    ? await list.Skip(parameter.PageSize * (parameter.PageNumber - 1)).Limit(parameter.PageSize).ToListAsync()
                    : await list.ToListAsync(),
            };

            return result;
        }

        public static PagedResponse<T> ToPagedList<T>(this IQueryable<T> list, PagingParameter parameter)
        {
            ValidatePagingParameter(parameter);

            PagedResponse<T> result = new PagedResponse<T>()
            {
                TotalCount = list.Count(),
                TotalPages = parameter.PageSize != 0
                    ? (list.Count() + parameter.PageSize - 1) / parameter.PageSize
                    : 1,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
                Data = parameter.PageSize != 0
                    ? list.Skip(parameter.PageSize * (parameter.PageNumber - 1)).Take(parameter.PageSize).ToList()
                    : list.ToList(),
            };

            return result;
        }

        private static void ValidatePagingParameter(PagingParameter parameter)
        {
            if (parameter.PageNumber < 1) throw new PagingException("Az oldalszám nem lehet kisebb 0-nál.");
            if (parameter.PageSize > maxPageSize) throw new PagingException($"Az oldalon legfeljebb {maxPageSize} adat jeleníthető meg.");
            if (parameter.PageSize < 0) throw new PagingException($"Az oldalon legalább 1 adatot meg kell jeleníteni.");
        }
    }
}
