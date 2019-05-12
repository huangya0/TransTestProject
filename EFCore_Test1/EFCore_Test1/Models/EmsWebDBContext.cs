using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore_Test1.Models
{
    public partial class EmsWebDBContext : DbContext
    {
        public EmsWebDBContext()
        {
        }

        public EmsWebDBContext(DbContextOptions<EmsWebDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CommonAuthenControllerActions> CommonAuthenControllerActions { get; set; }
        public virtual DbSet<CommonAuthenFunctionPermissionLevel> CommonAuthenFunctionPermissionLevel { get; set; }
        public virtual DbSet<CommonAuthenRole> CommonAuthenRole { get; set; }
        public virtual DbSet<CommonAuthenRoleFunctionPermission> CommonAuthenRoleFunctionPermission { get; set; }
        public virtual DbSet<CommonAuthenRoleUser> CommonAuthenRoleUser { get; set; }
        public virtual DbSet<CommonAuthenUser> CommonAuthenUser { get; set; }
        public virtual DbSet<CommonSiteMapMenu> CommonSiteMapMenu { get; set; }
        public virtual DbSet<Table1> Table1 { get; set; }
        public virtual DbSet<Table2> Table2 { get; set; }
        public virtual DbSet<Table3> Table3 { get; set; }
        public virtual DbSet<Table4> Table4 { get; set; }
        public virtual DbSet<Table5> Table5 { get; set; }
        public virtual DbSet<TblLogInfo> TblLogInfo { get; set; }
        public virtual DbSet<TblSample> TblSample { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmsWebDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CommonAuthenControllerActions>(entity =>
            {
                entity.ToTable("Common_Authen_ControllerActions");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PermissionLevelId).HasColumnName("PermissionLevelID");

                entity.HasOne(d => d.PermissionLevel)
                    .WithMany(p => p.CommonAuthenControllerActions)
                    .HasForeignKey(d => d.PermissionLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel");
            });

            modelBuilder.Entity<CommonAuthenFunctionPermissionLevel>(entity =>
            {
                entity.ToTable("Common_Authen_FunctionPermissionLevel");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionLevel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommonAuthenRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Common_Authen_Role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.ResourceKey).HasMaxLength(100);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CommonAuthenRoleFunctionPermission>(entity =>
            {
                entity.ToTable("Common_Authen_RoleFunctionPermission");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PermissionLevelId).HasColumnName("PermissionLevelID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.PermissionLevel)
                    .WithMany(p => p.CommonAuthenRoleFunctionPermission)
                    .HasForeignKey(d => d.PermissionLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CommonAuthenRoleFunctionPermission)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role");
            });

            modelBuilder.Entity<CommonAuthenRoleUser>(entity =>
            {
                entity.ToTable("Common_Authen_RoleUser");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CommonAuthenRoleUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Common_Authen_RoleUser_Common_Authen_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommonAuthenRoleUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Common_Authen_RoleUser_Common_Authen_User");
            });

            modelBuilder.Entity<CommonAuthenUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_tbl_User_1");

                entity.ToTable("Common_Authen_User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfbirth)
                    .HasColumnName("DateOFBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Idnumber)
                    .HasColumnName("IDNumber")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.LogonName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CommonSiteMapMenu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("Common_SiteMap_Menu");

                entity.Property(e => e.MenuId)
                    .HasColumnName("MenuID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActionName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.ResourceKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RouteValues)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Common_SiteMap_Menu_Common_SiteMap_Menu");
            });

            modelBuilder.Entity<Table1>(entity =>
            {
                entity.ToTable("Table_1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Table2>(entity =>
            {
                entity.ToTable("Table_2");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name1).HasMaxLength(10);
            });

            modelBuilder.Entity<Table3>(entity =>
            {
                entity.ToTable("Table_3");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Table4>(entity =>
            {
                entity.ToTable("Table_4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasMaxLength(10);

                entity.HasOne(d => d.P)
                    .WithMany(p => p.Table4)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("FK_Table_4_Table_2");
            });

            modelBuilder.Entity<Table5>(entity =>
            {
                entity.ToTable("Table_5");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblLogInfo>(entity =>
            {
                entity.ToTable("tbl_LogInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.Thread).IsRequired();
            });

            modelBuilder.Entity<TblSample>(entity =>
            {
                entity.ToTable("tbl_Sample");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
    }
}
