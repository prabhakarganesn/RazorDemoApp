using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DempApp.Models.DB;

public partial class DemoClientContext : DbContext
{
    public DemoClientContext()
    {
    }

    public DemoClientContext(DbContextOptions<DemoClientContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; } = null!;

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07B2B816D7");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.EmployeeType).HasColumnOrder(3);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(1);
            entity.Property(e => e.LastName)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnOrder(2);

            entity.HasOne(d => d.EmployeeTypeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__Employ__29572725");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07E3B8EB37");

            entity.ToTable("EmployeeType");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0711B36F39");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnOrder(2);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(1);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(3);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
