using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalFranklinGonzalez.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<catedratico> catedratico { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<catedratico>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<catedratico>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<catedratico>()
                .Property(e => e.Curso)
                .IsUnicode(false);

            modelBuilder.Entity<Cursos>()
                .Property(e => e.NombreCurso)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.List_activo)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.List_aprobados)
                .IsUnicode(false);

            modelBuilder.Entity<Reporte>()
                .Property(e => e.List_reprobado)
                .IsUnicode(false);
        }
    }
}
