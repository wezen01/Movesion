using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MVSNChallenge.Models.DB;

public partial class MvsnchallengeContext : DbContext
{
    public MvsnchallengeContext()
    {
    }

    public MvsnchallengeContext(DbContextOptions<MvsnchallengeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compagnie> Compagnies { get; set; }

    public virtual DbSet<Contatti> Contattis { get; set; }

    public virtual DbSet<Indirizzi> Indirizzis { get; set; }

    public virtual DbSet<Prodotti> Prodottis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

        var connectionString = configuration.GetConnectionString("DbCon");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compagnie>(entity =>
        {
            entity.ToTable("Compagnie");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NomeCompagnia).HasMaxLength(50);
        });

        modelBuilder.Entity<Contatti>(entity =>
        {
            entity.ToTable("Contatti");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Contatto).HasMaxLength(50);
            entity.Property(e => e.Idcompagnia).HasColumnName("IDCompagnia");
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.IdcompagniaNavigation).WithMany(p => p.Contattis)
                .HasForeignKey(d => d.Idcompagnia)
                .HasConstraintName("FK_Contatti_Compagnie");
        });

        modelBuilder.Entity<Indirizzi>(entity =>
        {
            entity.ToTable("Indirizzi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Citta).HasMaxLength(50);
            entity.Property(e => e.Idcompagnia).HasColumnName("IDCompagnia");
            entity.Property(e => e.Indirizzo).HasMaxLength(50);

            entity.HasOne(d => d.IdcompagniaNavigation).WithMany(p => p.Indirizzis)
                .HasForeignKey(d => d.Idcompagnia)
                .HasConstraintName("FK_Indirizzi_Compagnie");
        });

        modelBuilder.Entity<Prodotti>(entity =>
        {
            entity.ToTable("Prodotti");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoriaMerceologica).HasMaxLength(50);
            entity.Property(e => e.Idcompagnia).HasColumnName("IDCompagnia");
            entity.Property(e => e.NomeProdotto).HasMaxLength(50);

            entity.HasOne(d => d.IdcompagniaNavigation).WithMany(p => p.Prodottis)
                .HasForeignKey(d => d.Idcompagnia)
                .HasConstraintName("FK_Prodotti_Compagnie");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
