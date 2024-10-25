
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Blogify.Common.ApiQuery
{
    public class QueryOptions<TRequest>
    {
        public const int MaxPageSize = 100;
        private const int DefaultPageSize = 10;
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; } = DefaultPageSize;
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public bool? IsCount { get; set; } = false;

        public bool Validate()
        {
            return true;
        }
        public async Task<QueryResult<TResponse>> ApplyAsync<TResponse>(IQueryable<TResponse> query)
        {
            if (IsCount.HasValue && !IsCount.Value)
                return await ApplyPaging(query);

            return new QueryResult<TResponse>()
            {
                TotalCount = await query.CountAsync()
            };


        }

        public async Task<IQueryable<TResponse>> ApplyOrderBy<TResponse>(IQueryable<TResponse> query)
        {
            if (string.IsNullOrEmpty(OrderBy))
                return query;

            var items = OrderBy.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var option = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (option.Length > 2)
                    return null;

                query = query.OrderBy(ParsingConfig.Default, item);
            }
            return query;
        }

        public async Task<QueryResult<TResponse>> ApplyPaging<TResponse>(IQueryable<TResponse> query)
        {
            if (PageSize > MaxPageSize)
                PageSize = MaxPageSize;
            var totalCount = await query.CountAsync();
            query = query.Skip((PageNumber.Value - 1) * PageSize.Value).Take(PageSize.Value);
            return new QueryResult<TResponse>()
            {
                Result = query,
                TotalCount = totalCount
            };
        }

        public class FilterQueryOptions
        {
            public string PropertyName { get; set; }
            public int PropertyValue { get; set; }
        }

        public class OrderByQueryOptions
        {
            public string Name { get; set; }
            public OrderByDirection Direction { get; set; }
        }

        public enum OrderByDirection
        {
            Ascending,
            Descending,
        }
    }
}
