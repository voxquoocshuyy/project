using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Entities;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangDiem> BangDiems { get; set; }

    public virtual DbSet<HocVien> HocViens { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;user id=root;password=martialemblem152;port=3306;database=Project;ConvertZeroDateTime=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangDiem>(entity =>
        {
            entity.HasKey(e => e.MaHp).HasName("PRIMARY");

            entity.ToTable("BangDiem", "Project");

            entity.HasIndex(e => e.MaHv, "BangDiem_HocVien_MaHV_fk");

            entity.HasIndex(e => e.MaMh, "BangDiem_MonHoc_MaMH_fk");

            entity.HasIndex(e => e.MaHp, "MaHP").IsUnique();

            entity.Property(e => e.MaHp).HasColumnName("MaHP");
            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.MaMh).HasColumnName("MaMH");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.BangDiems)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("BangDiem_HocVien_MaHV_fk");

            entity.HasOne(d => d.MaMhNavigation).WithMany(p => p.BangDiems)
                .HasForeignKey(d => d.MaMh)
                .HasConstraintName("BangDiem_MonHoc_MaMH_fk");
        });

        modelBuilder.Entity<HocVien>(entity =>
        {
            entity.HasKey(e => e.MaHv).HasName("PRIMARY");

            entity.ToTable("HocVien", "Project");

            entity.HasIndex(e => e.MaHv, "MaHV").IsUnique();

            entity.Property(e => e.MaHv).HasColumnName("MaHV");
            entity.Property(e => e.Lop).HasMaxLength(3);
            entity.Property(e => e.TenHv)
                .HasMaxLength(255)
                .HasColumnName("TenHV");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.MaMh).HasName("PRIMARY");

            entity.ToTable("MonHoc", "Project");

            entity.HasIndex(e => e.MaMh, "MaMH").IsUnique();

            entity.Property(e => e.MaMh).HasColumnName("MaMH");
            entity.Property(e => e.TenMh)
                .HasMaxLength(255)
                .HasColumnName("TenMH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
