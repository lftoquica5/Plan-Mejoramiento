using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace INTENTO2.Modelo
{
    public partial class planmejoramientoContext : DbContext
    {
        public virtual DbSet<Empleados> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost; userid=root; password=; Database=planmejoramiento");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.Cedula);

                entity.ToTable("empleados");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Dias).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VacacionesPagar)
                    .HasColumnName("vacacionesPagar")
                    .HasColumnType("int(11)");
            });
        }
    }
}
