using Microsoft.AspNetCore.Mvc;
using Prod.Data.Contracts;
using Prod.Entities;

namespace Prod.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPermisoController : GenericController<TipoPermiso>
    {
        public TipoPermisoController(IRepository<TipoPermiso> repository) : base(repository) { }
    }
}
