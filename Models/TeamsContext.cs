using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Models;

public partial class TeamsContext : DbContext
{
    public TeamsContext()
    {
    }

    public TeamsContext(DbContextOptions<TeamsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Teams;User ID=sa;Password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Player__3214EC0791C28B72");

            entity.ToTable("Player");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.JersyNumber).HasColumnName("Jersy Number");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Player)
                .HasForeignKey<Player>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Player_Teams");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teams__3214EC07595A6924");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
