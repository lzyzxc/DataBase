﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySuperMarket.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyMarket : DbContext
    {
        public MyMarket()
            : base("name=MyMarket")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<EXPENSE> EXPENSE { get; set; }
        public virtual DbSet<INCOME> INCOME { get; set; }
        public virtual DbSet<PLAN> PLAN { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCT_ATTRIBUTE> PRODUCT_ATTRIBUTE { get; set; }
        public virtual DbSet<SALARY> SALARY { get; set; }
        public virtual DbSet<SALES_LOT> SALES_LOT { get; set; }
        public virtual DbSet<SHELF> SHELF { get; set; }
        public virtual DbSet<SPONSOR> SPONSOR { get; set; }
        public virtual DbSet<STOCK> STOCK { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIER { get; set; }
        public virtual DbSet<SUPPORT> SUPPORT { get; set; }
        public virtual DbSet<VIP> VIP { get; set; }
    }
}
