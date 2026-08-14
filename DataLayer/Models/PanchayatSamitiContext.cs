using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

public partial class PanchayatSamitiContext : DbContext
{
    public PanchayatSamitiContext()
    {
    }

    public PanchayatSamitiContext(DbContextOptions<PanchayatSamitiContext> options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public virtual DbSet<BankMaster> BankMasters { get; set; }

    public virtual DbSet<BankecheTapshilMaster> BankecheTapshilMasters { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<KaryalayaPramukh> KaryalayaPramukhs { get; set; }

    public virtual DbSet<KharchacheShirshMaster> KharchacheShirshMasters { get; set; }

    public virtual DbSet<KhatePramukhMaster> KhatePramukhMasters { get; set; }

    public virtual DbSet<PanchayatSamitiMaster> PanchayatSamitiMasters { get; set; }

    public virtual DbSet<RelationMaster> RelationMasters { get; set; }

    public virtual DbSet<RetirementOfficeMaster> RetirementOfficeMasters { get; set; }

    public virtual DbSet<SubDepartmentMaster> SubDepartmentMasters { get; set; }

    public virtual DbSet<VetanAyogMaster> VetanAyogMasters { get; set; }

    public virtual DbSet<VetanShreneeMaster> VetanShreneeMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=PanchayatSamiti;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankMast__3214EC077B423C1C");

            entity.ToTable("BankMaster");

            entity.Property(e => e.BankName).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });        

        modelBuilder.Entity<BankecheTapshilMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bankeche__3214EC077ECF1DEC");

            entity.ToTable("BankecheTapshilMaster");

            entity.Property(e => e.BankecheTapshil).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.ToTable("DepartmentMaster");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnType("bool");
            entity.Property(e => e.Createdby).HasMaxLength(10).IsFixedLength();
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(10).IsFixedLength();
        });
        

        modelBuilder.Entity<DesignationMaster>(entity =>
        {
            entity.ToTable("DesignationMaster");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasColumnType("datetime");
        });

        modelBuilder.Entity<KaryalayaPramukh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Karyalay__3214EC0773A21992");

            entity.ToTable("KaryalayaPramukh");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KaryalayaPramukh1)
                .HasMaxLength(200)
                .HasColumnName("KaryalayaPramukh");
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<KharchacheShirshMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kharchac__3214EC07984AD1BF");

            entity.ToTable("KharchacheShirshMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KharchacheShirsh).HasMaxLength(200);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<KhatePramukhMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KhatePra__3214EC07E3750E86");

            entity.ToTable("KhatePramukhMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.KhatePramukh).HasMaxLength(200);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<PanchayatSamitiMaster>(entity =>
        {
            entity.ToTable("PanchayatSamitiMaster");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RelationMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Relation__3214EC07B3657239");

            entity.ToTable("RelationMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Relation).HasMaxLength(200);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<RetirementOfficeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Retireme__3214EC07627F5E03");

            entity.ToTable("RetirementOfficeMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RetirementOffice).HasMaxLength(200);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<SubDepartmentMaster>(entity =>
        {
            entity.ToTable("SubDepartmentMaster");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VetanAyogMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VetanAyo__3214EC07881C9BE7");

            entity.ToTable("VetanAyogMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.VetanAyog).HasMaxLength(200);
        });

        modelBuilder.Entity<VetanShreneeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VetanShr__3214EC07E6827F3A");

            entity.ToTable("VetanShreneeMaster");

            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.VetanShrenee).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
