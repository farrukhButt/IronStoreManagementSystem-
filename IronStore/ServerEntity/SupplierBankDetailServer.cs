//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IronStore.ServerEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierBankDetailServer
    {
        public int SupplierBankId { get; set; }
        public int SupplierId { get; set; }
        public string AccountNo { get; set; }
        public int StationSupplierBankId { get; set; }
        public int StationSupplierId { get; set; }
        public int StatusCode { get; set; }
    
        public virtual SupplierServer SupplierServer { get; set; }
    }
}