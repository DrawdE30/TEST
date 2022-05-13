using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvaApi.Models
{
    public partial class UsuariosCTX : DbContext
    {
        public UsuariosCTX()
        {
        }

        public UsuariosCTX(DbContextOptions<UsuariosCTX> options)
            : base(options)
        {
        }

        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-508GC2P4\\SQLEXPRESS;Database=Evaluacion;User Id=sa;Password=S3guridadS@");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Unidad)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdProducto })
                    .HasName("PK__Sales__228C6526AF22A880");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Sale)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sales__IdProduct__286302EC");

                // entity.HasOne(d => d.IdProductoNavigation)
                //     .WithMany(p => p.Sales)
                //     .HasForeignKey(d => d.IdProducto)
                //     .OnDelete(DeleteBehavior.ClientSetNull)
                //     .HasConstraintName("FK__Sales__IdProduct__286302EC");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.NomUs)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Pass).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
