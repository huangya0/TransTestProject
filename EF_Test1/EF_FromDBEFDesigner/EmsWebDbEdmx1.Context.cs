﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF_FromDBEFDesigner
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmsWebDBEntities : DbContext
    {
        public EmsWebDBEntities()
            : base("name=EmsWebDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Table_1> Table_1 { get; set; }
        public virtual DbSet<Table_2> Table_2 { get; set; }
        public virtual DbSet<Table_3> Table_3 { get; set; }
        public virtual DbSet<Table_4> Table_4 { get; set; }
        public virtual DbSet<Table_5> Table_5 { get; set; }
    }
}