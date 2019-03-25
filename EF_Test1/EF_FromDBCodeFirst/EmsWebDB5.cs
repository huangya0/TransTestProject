namespace EF_FromDBCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmsWebDB5 : DbContext
    {
        public EmsWebDB5()
            : base("name=EmsWebDB5")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Common_Authen_ControllerActions>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_ControllerActions>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_ControllerActions>()
                .Property(e => e.ActionName)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_FunctionPermissionLevel>()
                .Property(e => e.FunctionName)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_FunctionPermissionLevel>()
                .Property(e => e.PermissionLevel)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_FunctionPermissionLevel>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_FunctionPermissionLevel>()
                .HasMany(e => e.Common_Authen_ControllerActions)
                .WithRequired(e => e.Common_Authen_FunctionPermissionLevel)
                .HasForeignKey(e => e.PermissionLevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Common_Authen_FunctionPermissionLevel>()
                .HasMany(e => e.Common_Authen_RoleFunctionPermission)
                .WithRequired(e => e.Common_Authen_FunctionPermissionLevel)
                .HasForeignKey(e => e.PermissionLevelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Common_Authen_Role>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Common_Authen_Role>()
                .HasMany(e => e.Common_Authen_RoleFunctionPermission)
                .WithRequired(e => e.Common_Authen_Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Common_Authen_User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_User>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_User>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Common_Authen_User>()
                .Property(e => e.IDNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Common_SiteMap_Menu>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<Common_SiteMap_Menu>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<Common_SiteMap_Menu>()
                .Property(e => e.ActionName)
                .IsUnicode(false);

            modelBuilder.Entity<Common_SiteMap_Menu>()
                .Property(e => e.RouteValues)
                .IsUnicode(false);

            modelBuilder.Entity<Common_SiteMap_Menu>()
                .HasMany(e => e.Common_SiteMap_Menu1)
                .WithOptional(e => e.Common_SiteMap_Menu2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<Table_2>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Table_2>()
                .Property(e => e.Name1)
                .IsFixedLength();

            modelBuilder.Entity<Table_2>()
                .HasMany(e => e.Table_4)
                .WithOptional(e => e.Table_2)
                .HasForeignKey(e => e.pid);

            modelBuilder.Entity<Table_3>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Table_3>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Table_4>()
                .Property(e => e.id)
                .IsFixedLength();

            modelBuilder.Entity<Table_4>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Table_4>()
                .Property(e => e.pid)
                .IsFixedLength();

            modelBuilder.Entity<Table_5>()
                .Property(e => e.id)
                .IsFixedLength();

            modelBuilder.Entity<Table_5>()
                .Property(e => e.name)
                .IsFixedLength();

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
