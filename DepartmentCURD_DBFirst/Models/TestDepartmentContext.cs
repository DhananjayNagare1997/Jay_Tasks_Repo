using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DepartmentCURD_DBFirst.Models;

public partial class TestDepartmentContext : DbContext
{
    public TestDepartmentContext()
    {
    }

    public TestDepartmentContext(DbContextOptions<TestDepartmentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDE004BD1D");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepartmentHead).HasMaxLength(255);
            entity.Property(e => e.DepartmentName).HasMaxLength(255);
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC071D8A8EB1");

            entity.ToTable("Employee");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
