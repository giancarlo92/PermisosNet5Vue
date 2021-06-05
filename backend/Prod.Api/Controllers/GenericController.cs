using Microsoft.AspNetCore.Mvc;
using Prod.Data.Contracts;
using Prod.Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prod.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T> : ControllerBase where T: BaseEntity
    {
        private readonly IRepository<T> repository;

        public GenericController(IRepository<T> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> Get()
        {
            return await repository.Get();
        }

        [HttpPost]
        public virtual async Task<ActionResult<int>> Post(T entity)
        {
            return await repository.Add(entity);
        }

        [HttpPut]
        public virtual async Task<ActionResult<int>> Put(T entity)
        {
            await repository.Update(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(int id)
        {
            await repository.Delete(id);
            return NoContent();
        }
    }
}
