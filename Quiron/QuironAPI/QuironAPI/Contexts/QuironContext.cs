using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuironAPI.Domains
{
    public partial class QuironContext : DbContext
    {
        public QuironContext()
        {
        }

        public QuironContext(DbContextOptions<QuironContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doutores> Doutores { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=T_Quiron;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doutores>(entity =>
            {
                entity.HasKey(e => e.IdDoutor);

                entity.HasIndex(e => e.Crm)
                    .HasName("UQ__Doutores__C1F887FF0D5F5AAA")
                    .IsUnique();

                entity.Property(e => e.IdDoutor).HasColumnName("idDoutor");

                entity.Property(e => e.Crm).HasColumnName("CRM");

                entity.Property(e => e.NomeDoutor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.PacientesNavigation)
                    .WithMany(p => p.Doutores)
                    .HasForeignKey(d => d.Pacientes)
                    .HasConstraintName("FK__Doutores__Pacien__5165187F");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.HasKey(e => e.IdPaciente);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Paciente__C1F89731B3644AE6")
                    .IsUnique();

                entity.Property(e => e.IdPaciente).HasColumnName("idPaciente");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
