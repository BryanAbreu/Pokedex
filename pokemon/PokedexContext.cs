using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pokedex.pokemon
{
    public partial class PokedexContext : DbContext
    {
        public PokedexContext()
        {
        }

        public PokedexContext(DbContextOptions<PokedexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<Regiones> Regiones { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CO74FS7\\SQLEXPRESS;Database=Pokedex;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasKey(e => e.Nombre)
                    .HasName("PK__pokemon__72AFBCC77F19D51F");

                entity.ToTable("pokemon");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ataque2)
                    .HasColumnName("ataque2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ataque3)
                    .HasColumnName("ataque3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ataque4)
                    .HasColumnName("ataque4")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ataques)
                    .IsRequired()
                    .HasColumnName("ataques")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasColumnName("region")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo2)
                    .HasColumnName("tipo2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RegionNavigation)
                    .WithMany(p => p.Pokemon)
                    .HasForeignKey(d => d.Region)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pokemon__region__412EB0B6");

                entity.HasOne(d => d.TipoNavigation)
                    .WithMany(p => p.PokemonTipoNavigation)
                    .HasForeignKey(d => d.Tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pokemon__tipo__398D8EEE");

                entity.HasOne(d => d.Tipo2Navigation)
                    .WithMany(p => p.PokemonTipo2Navigation)
                    .HasForeignKey(d => d.Tipo2)
                    .HasConstraintName("FK__pokemon__tipo2__5AEE82B9");
            });

            modelBuilder.Entity<Regiones>(entity =>
            {
                entity.HasKey(e => e.Region)
                    .HasName("PK__regiones__7AF3A905243AA830");

                entity.ToTable("regiones");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.Tipos)
                    .HasName("PK__tipo__E422316D5B9D8B51");

                entity.ToTable("tipo");

                entity.Property(e => e.Tipos)
                    .HasColumnName("tipos")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
