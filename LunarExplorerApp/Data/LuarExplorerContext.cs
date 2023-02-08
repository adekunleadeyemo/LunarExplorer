using System;
using System.Collections.Generic;
using LunarExplorer.Model;
using Microsoft.EntityFrameworkCore;

namespace LunarExplorer.Data;

public partial class LuarExplorerContext : DbContext
{
    public LuarExplorerContext(DbContextOptions<LuarExplorerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plateau> Plateaus { get; set; }

    public virtual DbSet<Rover> Rovers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plateau>(entity =>
        {
            entity.ToTable("Plateau");

            entity.HasIndex(e => e.Id, "IX_Plateau_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Breadth).HasColumnName("breadth");
            entity.Property(e => e.Length).HasColumnName("length");
        });

        modelBuilder.Entity<Rover>(entity =>
        {
            entity.ToTable("Rover");

            entity.HasIndex(e => e.Id, "IX_Rover_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Directions).HasColumnName("directions");
            entity.Property(e => e.Orient).HasColumnName("orient");
            entity.Property(e => e.XCord).HasColumnName("x_cord");
            entity.Property(e => e.YCord).HasColumnName("y_cord");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
