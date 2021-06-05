using Prod.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prod.Data.Contracts
{
    public interface IRepository<T>
    {
        Task<int> Add(T entity);
        Task Delete(int id);
        Task Update(T entity);
        Task<List<T>> Get();
        Task<int> Count(Expression<Func<T, bool>> where);
        Task<T> GetById(int id);
        Task<List<T>> FindBy(QueryParameters<T> queryParameters);
    }
}
