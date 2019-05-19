using System.Collections.Generic;
using System.Data.SqlClient;
using EMS.Utility.Data;

namespace EMS.DataProvider.Contexts
{
    using System;
    //using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EMS.DataProvider.Models;
    using EMS.DataProvider.Common;
    using EMS.DataProvider.Models.Common;
    using Microsoft.EntityFrameworkCore;
    using EMS.Utility.Web;

    /// <summary>
    /// 注意ChildrenMenug与ParentMenu需在EF自动生成后手动改
    /// https://www.cnblogs.com/chongyao/p/9068007.html
    /// https://docs.microsoft.com/en-us/ef/core/
    /// </summary>
    public partial class EmsWebDB : BaseContext
    {
        public EmsWebDB(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public EmsWebDB()
            : base(new DbContextOptions<BaseContext>())
        {
        }

        public virtual DbSet<Common_Authen_ControllerActions> Common_Authen_ControllerActions { get; set; }
        public virtual DbSet<Common_Authen_FunctionPermissionLevel> Common_Authen_FunctionPermissionLevel { get; set; }
        public virtual DbSet<Common_Authen_Role> Common_Authen_Role { get; set; }
        public virtual DbSet<Common_Authen_RoleFunctionPermission> Common_Authen_RoleFunctionPermission { get; set; }
        public virtual DbSet<Common_Authen_RoleUser> Common_Authen_RoleUser { get; set; }
        public virtual DbSet<Common_Authen_User> Common_Authen_User { get; set; }
        public virtual DbSet<Common_SiteMap_Menu> Common_SiteMap_Menu { get; set; }
        public virtual DbSet<Table_1> Table_1 { get; set; }
        public virtual DbSet<Table_2> Table_2 { get; set; }
        public virtual DbSet<Table_3> Table_3 { get; set; }
        public virtual DbSet<Table_4> Table_4 { get; set; }
        public virtual DbSet<Table_5> Table_5 { get; set; }
        public virtual DbSet<tbl_LogInfo> tbl_LogInfo { get; set; }
        public virtual DbSet<tbl_Sample> tbl_Sample { get; set; }
        public virtual DbSet<vw_Authen_RolePermissions> vw_Authen_RolePermissions { get; set; }

        public static string ConnectionString; // { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EmsWebDB;Integrated Security=True");
                //"ConnectionStrings": {
                //    "TestNetCoreEF": "Data Source={your sql server host address};Initial Catalog=TestNetCoreEF;user id={your username};password={your password};"
                //},
                //string connectionStr = ConfigurationHelper.GetConnectionString("EmsWebDB");
                //optionsBuilder.UseSqlServer(connectionStr);
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Common_Authen_ControllerActions>(entity =>
            {
                entity.ToTable("Common_Authen_ControllerActions");

                entity.Property(e => e.ID)
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

                entity.Property(e => e.PermissionLevelID).HasColumnName("PermissionLevelID");

                entity.HasOne(d => d.Common_Authen_FunctionPermissionLevel)
                    .WithMany(p => p.Common_Authen_ControllerActions)
                    .HasForeignKey(d => d.PermissionLevelID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Common_Authen_ControllerActions_Common_Authen_FunctionPermissionLevel");
            });

            modelBuilder.Entity<Common_Authen_FunctionPermissionLevel>(entity =>
            {
                entity.ToTable("Common_Authen_FunctionPermissionLevel");

                entity.Property(e => e.ID)
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

            modelBuilder.Entity<Common_Authen_Role>(entity =>
            {
                entity.HasKey(e => e.RoleID);

                entity.ToTable("Common_Authen_Role");

                entity.Property(e => e.RoleID)
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

            modelBuilder.Entity<Common_Authen_RoleFunctionPermission>(entity =>
            {
                entity.ToTable("Common_Authen_RoleFunctionPermission");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.PermissionLevelID).HasColumnName("PermissionLevelID");

                entity.Property(e => e.RoleID).HasColumnName("RoleID");

                entity.HasOne(d => d.Common_Authen_FunctionPermissionLevel)
                    .WithMany(p => p.Common_Authen_RoleFunctionPermission)
                    .HasForeignKey(d => d.PermissionLevelID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Common_Authen_RoleFunctionPermission_Common_Authen_FunctionPermissionLevel");

                entity.HasOne(d => d.Common_Authen_Role)
                    .WithMany(p => p.Common_Authen_RoleFunctionPermission)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Common_Authen_RoleFunctionPermission_Common_Authen_Role");
            });

            modelBuilder.Entity<Common_Authen_RoleUser>(entity =>
            {
                entity.ToTable("Common_Authen_RoleUser");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.RoleID).HasColumnName("RoleID");

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.HasOne(d => d.Common_Authen_Role)
                    .WithMany(p => p.Common_Authen_RoleUser)
                    .HasForeignKey(d => d.RoleID)
                    .HasConstraintName("FK_Common_Authen_RoleUser_Common_Authen_Role");

                entity.HasOne(d => d.Common_Authen_User)
                    .WithMany(p => p.Common_Authen_RoleUser)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_Common_Authen_RoleUser_Common_Authen_User");
            });

            modelBuilder.Entity<Common_Authen_User>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .HasName("PK_tbl_User_1");

                entity.ToTable("Common_Authen_User");

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOFBirth)
                    .HasColumnName("DateOFBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.IDNumber)
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

            modelBuilder.Entity<Common_SiteMap_Menu>(entity =>
            {
                entity.HasKey(e => e.MenuID);

                entity.ToTable("Common_SiteMap_Menu");

                entity.Property(e => e.MenuID)
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

                entity.Property(e => e.ParentID).HasColumnName("ParentID");

                entity.Property(e => e.ResourceKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RouteValues)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentMenu)
                    .WithMany(p => p.ChildrenMenu)
                    .HasForeignKey(d => d.ParentID)
                    .HasConstraintName("FK_Common_SiteMap_Menu_Common_SiteMap_Menu");
            });

            modelBuilder.Entity<Table_1>(entity =>
            {
                entity.ToTable("Table_1");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Table_2>(entity =>
            {
                entity.ToTable("Table_2");

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name1).HasMaxLength(10);
            });

            modelBuilder.Entity<Table_3>(entity =>
            {
                entity.ToTable("Table_3");

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<Table_4>(entity =>
            {
                entity.ToTable("Table_4");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.pid)
                    .HasColumnName("pid")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Table_2)
                    .WithMany(p => p.Table_4)
                    .HasForeignKey(d => d.pid)
                    .HasConstraintName("FK_Table_4_Table_2");
            });

            modelBuilder.Entity<Table_5>(entity =>
            {
                entity.ToTable("Table_5");

                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<tbl_LogInfo>(entity =>
            {
                entity.ToTable("tbl_LogInfo");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.LogTime).HasColumnType("datetime");

                entity.Property(e => e.Thread).IsRequired();
            });

            modelBuilder.Entity<tbl_Sample>(entity =>
            {
                entity.ToTable("tbl_Sample");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<vw_Authen_RolePermissions>()
                .HasKey(p => new { p.RoleID, p.RoleName, p.Controller, p.ActionName, p.HasActionPermission });

            modelBuilder.Entity<vw_Authen_RolePermissions>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<vw_Authen_RolePermissions>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<vw_Authen_RolePermissions>()
                .Property(e => e.ActionName)
                .IsUnicode(false);
        }
    }
}
