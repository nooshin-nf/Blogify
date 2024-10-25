namespace Blogify.Common.ApiQuery
{
    public class QueryResult<T>
    {
        public IEnumerable<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
