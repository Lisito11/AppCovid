using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AppCovid.Server
{
    public partial class dajd2mj0ciopa3Context : DbContext
    {
        public dajd2mj0ciopa3Context()
        {
        }

        public dajd2mj0ciopa3Context(DbContextOptions<dajd2mj0ciopa3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("direccion");

                entity.Property(e => e.Id)
                    .HasColumnName("direccion_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Calle)
                    .HasMaxLength(150)
                    .HasColumnName("calle");

                entity.Property(e => e.Latitud).HasColumnName("latitud");

                entity.Property(e => e.Logitud).HasColumnName("logitud");

                entity.Property(e => e.PaisId).HasColumnName("pais_id");

                entity.Property(e => e.ProvinciaId).HasColumnName("provincia_id");

                entity.Property(e => e.Sector)
                    .HasMaxLength(100)
                    .HasColumnName("sector");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("fk_direccion_pais");

                entity.HasOne(d => d.Provincia)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.ProvinciaId)
                    .HasConstraintName("fk_direccion_provincia");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("pais_pkey");

                entity.ToTable("pais");

                entity.Property(e => e.Id)
                    .HasColumnName("pais_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.NombrePais)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nombre_pais");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id)
                    .HasColumnName("persona_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Apellido1)
                    .HasMaxLength(80)
                    .HasColumnName("apellido1");

                entity.Property(e => e.Apellido2)
                    .HasMaxLength(80)
                    .HasColumnName("apellido2");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .HasColumnName("cedula");

                entity.Property(e => e.DireccionId).HasColumnName("direccion_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.EstatusCovid).HasColumnName("estatus_covid");

                entity.Property(e => e.Justifacion).HasColumnName("justifacion");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(80)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoSangre)
                    .HasMaxLength(25)
                    .HasColumnName("tipo_sangre");

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.DireccionId)
                    .HasConstraintName("fk_persona_direccion");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("provincia_pkey");

                entity.ToTable("provincia");

                entity.Property(e => e.Id)
                    .HasColumnName("provincia_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.NombreProvincia)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nombre_provincia");

                entity.Property(e => e.PaisId).HasColumnName("pais_id");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.PaisId)
                    .HasConstraintName("fk_provincia_pais");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
