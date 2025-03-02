using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ViperHub.Domain.Models;

namespace ViperHub.Infrastructure.Persistence;

public partial class ViperHubContext : DbContext
{


    public ViperHubContext(DbContextOptions<ViperHubContext> options)
        : base(options)
    {

    }

    public virtual DbSet<CategoriasForo> CategoriasForos { get; set; }

    public virtual DbSet<Clane> Clanes { get; set; }

    public virtual DbSet<ComentariosForo> ComentariosForos { get; set; }

    public virtual DbSet<EquiposTorneo> EquiposTorneos { get; set; }

    public virtual DbSet<Multimedium> Multimedia { get; set; }

    public virtual DbSet<TemasForo> TemasForos { get; set; }

    public virtual DbSet<Torneo> Torneos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioClane> UsuarioClanes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriasForo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0793A2D80E");

            entity.ToTable("CategoriasForo");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F626AD2635").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Clane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clanes__3214EC0788C5C44B");

            entity.HasIndex(e => e.Name, "UQ__Clanes__737584F61923BAF7").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.ImagenUrl).HasMaxLength(255);
            entity.Property(e => e.LiderId).HasColumnName("Lider_id");
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Lider).WithMany(p => p.Clanes)
                .HasForeignKey(d => d.LiderId)
                .HasConstraintName("FK__Clanes__Lider_id__4F7CD00D");
        });

        modelBuilder.Entity<ComentariosForo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC07F38D0130");

            entity.ToTable("ComentariosForo");

            entity.Property(e => e.ComentarioPadreId).HasColumnName("ComentarioPadre_Id");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TemaForoId).HasColumnName("TemaForo_Id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

            entity.HasOne(d => d.ComentarioPadre).WithMany(p => p.InverseComentarioPadre)
                .HasForeignKey(d => d.ComentarioPadreId)
                .HasConstraintName("FK__Comentari__Comen__66603565");

            entity.HasOne(d => d.TemaForo).WithMany(p => p.ComentariosForos)
                .HasForeignKey(d => d.TemaForoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__TemaF__656C112C");

            entity.HasOne(d => d.Usuario).WithMany(p => p.ComentariosForos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__Usuar__6477ECF3");
        });

        modelBuilder.Entity<EquiposTorneo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EquiposT__3214EC07E1BC6C1A");

            entity.ToTable("EquiposTorneo");

            entity.Property(e => e.ClanId).HasColumnName("Clan_Id");
            entity.Property(e => e.Points).HasDefaultValue(0);
            entity.Property(e => e.TorneoId).HasColumnName("Torneo_Id");

            entity.HasOne(d => d.Clan).WithMany(p => p.EquiposTorneos)
                .HasForeignKey(d => d.ClanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EquiposTo__Clan___797309D9");

            entity.HasOne(d => d.Torneo).WithMany(p => p.EquiposTorneos)
                .HasForeignKey(d => d.TorneoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EquiposTo__Torne__7A672E12");
        });

        modelBuilder.Entity<Multimedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Multimed__3214EC07B90E93CE");

            entity.Property(e => e.FechaSubida)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(10);
            entity.Property(e => e.Url).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Multimedia)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Multimedi__User___7F2BE32F");
        });

        modelBuilder.Entity<TemasForo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TemasFor__3214EC0776E9EA2D");

            entity.ToTable("TemasForo");

            entity.Property(e => e.CategoriaForoId).HasColumnName("CategoriaForo_Id");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

            entity.HasOne(d => d.CategoriaForo).WithMany(p => p.TemasForos)
                .HasForeignKey(d => d.CategoriaForoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TemasForo__Categ__60A75C0F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.TemasForos)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TemasForo__Usuar__5FB337D6");
        });

        modelBuilder.Entity<Torneo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Torneos__3214EC079A3F6214");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.Torneos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Torneos__User_Id__6C190EBB");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC071A73DE66");

            entity.HasIndex(e => e.Username, "UQ__Usuarios__536C85E4DA5B4112").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105341F799FB3").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.RegisterDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioClane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsuarioC__3214EC077BB1F535");

            entity.Property(e => e.ClanId).HasColumnName("Clan_Id");
            entity.Property(e => e.Rol).HasMaxLength(20);
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_Id");

            entity.HasOne(d => d.Clan).WithMany(p => p.UsuarioClanes)
                .HasForeignKey(d => d.ClanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioCl__Clan___59063A47");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioClanes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UsuarioCl__Usuar__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
