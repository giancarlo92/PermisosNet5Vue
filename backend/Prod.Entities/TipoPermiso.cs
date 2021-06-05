using Prod.Entities.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Prod.Entities
{
    public class TipoPermiso : BaseEntity
    {
        [Required]
        public string Descripcion { get; set; }
    }
}
