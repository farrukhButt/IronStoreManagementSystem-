﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IronStore.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FaridiaIronStoreEntities : DbContext
    {
        public FaridiaIronStoreEntities()
            : base("name=FaridiaIronStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<LoanReturned> LoanReturneds { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierBankDetail> SupplierBankDetails { get; set; }
        public virtual DbSet<SupplierDuePayment> SupplierDuePayments { get; set; }
        public virtual DbSet<SupplierPaymentMade> SupplierPaymentMades { get; set; }
        public virtual DbSet<OrderPaymentMade> OrderPaymentMades { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}