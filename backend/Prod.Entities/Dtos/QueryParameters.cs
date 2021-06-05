using System;
using System.Linq.Expressions;

namespace Prod.Entities.Dtos
{
    public class QueryParameters<T>
    {
        public QueryParameters(int page, int limit)
        {
            Page = page;
            Limit = limit;
            Where = null;
            OrderBy = null;
            OrderByDescending = null;
        }

        public int Page { get; set; }
        public int Limit { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
        public Func<T, object> OrderBy { get; set; }
        public Func<T, object> OrderByDescending { get; set; }
    }
}
