using Microsoft.EntityFrameworkCore;
using Prod.Data.Contracts;
using Prod.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Prod.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<int> Count(Expression<Func<T, bool>> where)
        {
            return await context.Set<T>().Where(where).CountAsync();
        }

        public async Task Delete(int id)
        {
            var entidad = new T() { Id = id };
            context.Entry(entidad).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> FindBy(QueryParameters<T> queryParameters)
        {
            var orderByClass = ObtenerOrderBy(queryParameters);
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (queryParameters.Where == null) ? whereTrue : queryParameters.Where;

                if (orderByClass.IsAscending)
                {
                    var orderBy = context.Set<T>().Where(where).OrderBy(orderByClass.OrderBy)
                    .Skip((queryParameters.Page - 1) * queryParameters.Limit)
                    .Take(queryParameters.Limit).AsQueryable();
                    return await orderBy.ToListAsync();
                }
                else
                {
                    var orderByDescending = context.Set<T>().Where(where).OrderByDescending(orderByClass.OrderBy)
                    .Skip((queryParameters.Page - 1) * queryParameters.Limit)
                    .Take(queryParameters.Limit).AsQueryable();
                    return await orderByDescending.ToListAsync();
                }
        }

        public async Task<List<T>> Get()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        private OrderByClass<T> ObtenerOrderBy(QueryParameters<T> queryParameters)
        {
            if (queryParameters.OrderBy == null && queryParameters.OrderByDescending == null)
            {
                return new OrderByClass<T>(x => x.Id, true);
            }

            return (queryParameters.OrderBy != null)
                ? new OrderByClass<T>(queryParameters.OrderBy, true) 
                : new OrderByClass<T>(queryParameters.OrderByDescending, false);
        }
    }
}
