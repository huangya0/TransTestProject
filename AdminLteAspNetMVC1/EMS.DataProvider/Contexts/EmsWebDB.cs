namespace EMS.DataProvider.Contexts
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EMS.DataProvider.Models;
    using EMS.DataProvider.Common;

    public partial class EmsWebDB : BaseContext
    {
        public EmsWebDB()
            : base("name=EmsWebDB")
        {
        }

        public virtual DbSet<Table_1> Table_1 { get; set; }
        public virtual DbSet<Table_2> Table_2 { get; set; }
        public virtual DbSet<Table_3> Table_3 { get; set; }
        public virtual DbSet<Table_4> Table_4 { get; set; }
        public virtual DbSet<Table_5> Table_5 { get; set; }
        public virtual DbSet<tbl_LogInfo> tbl_LogInfo { get; set; }
        public virtual DbSet<tbl_Sample> tbl_Sample { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        }
    }
}
