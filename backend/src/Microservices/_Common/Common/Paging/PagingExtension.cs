using Common.Exceptions;
using Microsoft.EntityFrameworkCore;
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
                TotalPages = (await list.CountAsync() + parameter.PageSize - 1) / parameter.PageSize,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
                Data = await list.Skip(parameter.PageSize * (parameter.PageNumber - 1)).Take(parameter.PageSize).ToListAsync()
            };

            return result;
        }

        public static PagedResponse<T> ToPagedList<T>(this IQueryable<T> list, PagingParameter parameter)
        {
            ValidatePagingParameter(parameter);

            PagedResponse<T> result = new PagedResponse<T>()
            {
                TotalCount = list.Count(),
                TotalPages = (list.Count() + parameter.PageSize - 1) / parameter.PageSize,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize,
                Data = list.Skip(parameter.PageSize * (parameter.PageNumber - 1)).Take(parameter.PageSize).ToList()
            };

            return result;
        }

        private static void ValidatePagingParameter(PagingParameter parameter)
        {
            if (parameter.PageNumber < 1) throw new PagingException("Az oldalszám nem lehet kisebb 0-nál.");
            if (parameter.PageSize > maxPageSize) throw new PagingException($"Az oldalon legfeljebb {maxPageSize} adat jeleníthető meg.");
            if (parameter.PageSize < 1) throw new PagingException($"Az oldalon legalább 1 adatot meg kell jeleníteni.");
        }
    }
}
