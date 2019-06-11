using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestAdoDotNetConsole1.Models
{
    public partial class EEMSContext : DbContext
    {
        public EEMSContext()
        {
        }

        public EEMSContext(DbContextOptions<EEMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClientInfo> ClientInfo { get; set; }
        public virtual DbSet<ClientRegHistory> ClientRegHistory { get; set; }
        public virtual DbSet<Cube> Cube { get; set; }
        public virtual DbSet<CubeEquipModelRel> CubeEquipModelRel { get; set; }
        public virtual DbSet<CubeModel> CubeModel { get; set; }
        public virtual DbSet<EquipModel> EquipModel { get; set; }
        public virtual DbSet<EquipModelPtValue> EquipModelPtValue { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentChannel> EquipmentChannel { get; set; }
        public virtual DbSet<GroupInfo> GroupInfo { get; set; }
        public virtual DbSet<GroupRightAssign> GroupRightAssign { get; set; }
        public virtual DbSet<Pcc> Pcc { get; set; }
        public virtual DbSet<PointValue> PointValue { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<UserGroupAssign> UserGroupAssign { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserRight> UserRight { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=172.16.1.92;Initial Catalog=EEMS;Persist Security Info=False;User ID=sa;Password=cs2019;");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ClientInfo>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__ClientIn__737584F6CBE04389")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.IpAddress)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<ClientRegHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.QuiteDesc).HasMaxLength(120);

                entity.Property(e => e.QuiteTime).HasColumnType("datetime");

                entity.Property(e => e.RegisterTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cube>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Cube__737584F64C82273B")
                    .IsUnique();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CubeEquipModelRel>(entity =>
            {
                entity.HasIndex(e => new { e.EquipModelId, e.CubeModelId })
                    .HasName("UQ__CubeEqui__F1DF828D7103FA7A")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EquipmentCount).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CubeModel>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__CubeMode__737584F6E7D69D26")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipModel>(entity =>
            {
                entity.HasIndex(e => e.Abbreviation)
                    .HasName("UQ__EquipMod__9C41170E731E6F54")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__EquipMod__737584F6FFFFBA67")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PortType).HasDefaultValueSql("((3))");

                entity.Property(e => e.ProtocolDllName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EquipModelPtValue>(entity =>
            {
                entity.HasIndex(e => new { e.EquipModelId, e.Name })
                    .HasName("UQ__EquipMod__7B5C8B71D1653F51")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Equipmen__737584F60235F3D1")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentChannel>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Equipmen__737584F60AA14BAC")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PortParameters)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ProtocolName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProtocolParam).HasMaxLength(4000);
            });

            modelBuilder.Entity<GroupInfo>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UP_GroupInfo__Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GroupRightAssign>(entity =>
            {
                entity.HasIndex(e => new { e.GroupId, e.RightId })
                    .HasName("UP_GroupRightAssign_GroupId_RightId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Pcc>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Pcc__737584F6F0A290BF")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PointValue>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.EquipmentId })
                    .HasName("UQ__PointVal__F031F0B12F55CEBC")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Station__737584F6A991948F")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserGroupAssign>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.GroupId })
                    .HasName("UP_UserGroupAssign_UserId_GroupId")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__UserInfo__737584F6FB196D5D")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ChangePwdAtFirst)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telephone).HasMaxLength(13);
            });

            modelBuilder.Entity<UserRight>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UP_UserRight_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
