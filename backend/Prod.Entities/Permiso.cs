using Prod.Entities.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Prod.Entities
{
    public class Permiso : BaseEntity
    {
        [Required]
        public string NombreEmpleado { get; set; }
        [Required]
        public string ApellidosEmpleado { get; set; }
        [Required]
        public int TipoPermisoId { get; set; }
        public virtual TipoPermiso TipoPermiso { get; set; }
        [Required]
        public DateTime FechaPermiso { get; set; }
    }
}
