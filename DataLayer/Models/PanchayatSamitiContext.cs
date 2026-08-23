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
    }

    public virtual DbSet<AdhiSuchanaForm> AdhiSuchanaForms { get; set; }

    public virtual DbSet<AdhiSuchanaMaster> AdhiSuchanaMasters { get; set; }

    public virtual DbSet<BankMaster> BankMasters { get; set; }

    public virtual DbSet<BankecheTapshilMaster> BankecheTapshilMasters { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<KaryalayaPramukh> KaryalayaPramukhs { get; set; }

    public virtual DbSet<KharchacheShirshMaster> KharchacheShirshMasters { get; set; }

    public virtual DbSet<KhatePramukhMaster> KhatePramukhMasters { get; set; }

    public virtual DbSet<PanchayatSamitiMaster> PanchayatSamitiMasters { get; set; }

    public virtual DbSet<PensionHolderInformation> PensionHolderInformations { get; set; }

    public virtual DbSet<RelationMaster> RelationMasters { get; set; }

    public virtual DbSet<RetirementOfficeMaster> RetirementOfficeMasters { get; set; }

    public virtual DbSet<RoleMaster> RoleMasters { get; set; }

    public virtual DbSet<SubDepartmentMaster> SubDepartmentMasters { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VetanAyogMaster> VetanAyogMasters { get; set; }

    public virtual DbSet<VetanShreneeMaster> VetanShreneeMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=PanchayatSamiti;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdhiSuchanaForm>(entity =>
        {
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<AdhiSuchanaMaster>(entity =>
        {
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<BankMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankMast__3214EC077B423C1C");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<BankecheTapshilMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bankeche__3214EC077ECF1DEC");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.Property(e => e.Createdby).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<KaryalayaPramukh>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Karyalay__3214EC0773A21992");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<KharchacheShirshMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kharchac__3214EC07984AD1BF");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<KhatePramukhMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KhatePra__3214EC07E3750E86");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<PensionHolderInformation>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).IsFixedLength();
            entity.Property(e => e.IsDisabilityPensionPayable).IsFixedLength();
            entity.Property(e => e.UpdatedBy).IsFixedLength();
        });

        modelBuilder.Entity<RelationMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Relation__3214EC07B3657239");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<RetirementOfficeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Retireme__3214EC07627F5E03");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_RoleMaster");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_UserRoles");
        });

        modelBuilder.Entity<VetanAyogMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VetanAyo__3214EC07881C9BE7");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<VetanShreneeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VetanShr__3214EC07E6827F3A");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UniqueId).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
