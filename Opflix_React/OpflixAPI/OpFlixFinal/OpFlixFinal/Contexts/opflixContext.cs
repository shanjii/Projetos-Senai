using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpFlixFinal.Domains
{
    public partial class opflixContext : DbContext
    {
        public opflixContext()
        {
        }

        public opflixContext(DbContextOptions<opflixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Lancamentos> Lancamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=Opflix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.HasIndex(e => e.NomeCategoria)
                    .HasName("UQ__Categori__98459A0BD9D1AD8B")
                    .IsUnique();

                entity.Property(e => e.NomeCategoria)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lancamentos>(entity =>
            {
                entity.HasKey(e => e.IdLancamento);

                entity.HasIndex(e => e.NomeLancamento)
                    .HasName("UQ__Lancamen__4F88F976B0459843")
                    .IsUnique();

                entity.Property(e => e.Duracao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lancamento).HasColumnType("date");

                entity.Property(e => e.NomeLancamento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Lancamentos)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK__Lancament__Categ__4F7CD00D");

                entity.Property(e => e.Imagem)
                    .HasMaxLength(2083);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534B3580194")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
        }
    }
}
