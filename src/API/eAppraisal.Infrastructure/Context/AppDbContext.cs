using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eAppraisal.Domain.Entities;

namespace eAppraisal.Infrastructure.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appraisal> Appraisals { get; set; }

    public virtual DbSet<AppraisalStatusMaster> AppraisalStatusMasters { get; set; }

    public virtual DbSet<Compensation> Compensations { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeComments> EmployeeComments { get; set; }

    public virtual DbSet<ManagerComments> ManagerComments { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appraisal>(entity =>
        {
            entity.HasKey(e => e.AppraisalId).HasName("PK__Appraisa__711680160F58953A");

            entity.ToTable("Appraisal");

            entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Employee).WithMany(p => p.AppraisalEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appraisal_Employee");

            entity.HasOne(d => d.Manager).WithMany(p => p.AppraisalManagers)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appraisal_Manager");

            entity.HasOne(d => d.Status).WithMany(p => p.Appraisals)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appraisal_Status");
        });

        modelBuilder.Entity<AppraisalStatusMaster>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Appraisa__C8EE20436D14D76B");

            entity.ToTable("AppraisalStatusMaster");

            entity.HasIndex(e => e.StatusName, "UQ__Appraisa__05E7698ACD8D2D3F").IsUnique();

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Compensation>(entity =>
        {
            entity.HasKey(e => e.CompensationId).HasName("PK__Compensa__14AB977932D35F5D");

            entity.ToTable("Compensation");

            entity.Property(e => e.CompensationId).HasColumnName("CompensationID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");
            entity.Property(e => e.BasicSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DearnessAllowance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FoodAllowance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HouseRentAllowance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.Promoted).HasDefaultValue(false);
            entity.Property(e => e.ProvidentFund).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Appraisal).WithMany(p => p.Compensations)
                .HasForeignKey(d => d.AppraisalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compensation_Appraisal");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF15BD2156A");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.Email, "UQ__Employee__A9D10534C2F475F2").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.MaritalStatus).HasMaxLength(20);
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Pan)
                .HasMaxLength(20)
                .HasColumnName("PAN");
            entity.Property(e => e.PassportNo).HasMaxLength(20);
            entity.Property(e => e.PersonalPhone).HasMaxLength(20);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.ReportsToNavigation).WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo)
                .HasConstraintName("FK_Employee_Manager");
        });

        modelBuilder.Entity<EmployeeComments>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Employee__C3B4DFAAB6F24476");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Appraisal).WithMany(p => p.EmployeeComments)
                .HasForeignKey(d => d.AppraisalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeComments_Appraisal");
        });

        modelBuilder.Entity<ManagerComments>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__ManagerC__C3B4DFAAF58A97D6");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.AppraisalId).HasColumnName("AppraisalID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Appraisal).WithMany(p => p.ManagerComments)
                .HasForeignKey(d => d.AppraisalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ManagerComments_Appraisal");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserLogi__1788CCAC7CC04C86");

            entity.ToTable("UserLogin");

            entity.HasIndex(e => e.Username, "UQ__UserLogi__536C85E4EA8A7E4D").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AddedBy).HasMaxLength(50);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.FailedAttempts).HasDefaultValue(0);
            entity.Property(e => e.IsLocked).HasDefaultValue(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.ModifyAt).HasColumnType("datetime");
            entity.Property(e => e.ModifyBy).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogin_Employee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
