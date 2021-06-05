using Microsoft.EntityFrameworkCore;
using Prod.Entities;
using System;
using System.Collections.Generic;

namespace Prod.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tipoPermisos = new List<TipoPermiso>()
            {
                new TipoPermiso {Id = 1, Descripcion = "Enfermedad", CreatedBy = "gzevallos", CreatedOn = DateTime.Now},
                new TipoPermiso {Id = 2, Descripcion = "Diligencias", CreatedBy = "gzevallos", CreatedOn = DateTime.Now},
                new TipoPermiso {Id = 3, Descripcion = "Otros", CreatedBy = "gzevallos", CreatedOn = DateTime.Now}
            };
            
            modelBuilder.Entity<TipoPermiso>().HasData(tipoPermisos);

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Embarcaciones> Embarcaciones { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<TipoPermiso> TipoPermiso { get; set; }
    }
}
