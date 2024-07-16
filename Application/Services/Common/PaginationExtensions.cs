using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Common
{
    public static class PaginationExtensions
    {
        public static PagedResponse<List<T>> ToPagedResponse<T>(
            this IEnumerable<T> source,
            IPaginationParams paginationParams)
        {
            var totalRecords = source.Count();

            var items = source
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToList();

            return new PagedResponse<List<T>>(items, paginationParams.PageNumber, paginationParams.PageSize, totalRecords);
        }
    }
}
