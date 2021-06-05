using Microsoft.AspNetCore.Mvc;
using Prod.Data.Contracts;
using Prod.Entities;
using System.Threading.Tasks;

namespace Prod.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : GenericController<Permiso>
    {
        private readonly IRepository<Permiso> repository;

        public PermisoController(IRepository<Permiso> repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permiso>> GetById(int id)
        {
            return await repository.GetById(id);
        }
    }
}
