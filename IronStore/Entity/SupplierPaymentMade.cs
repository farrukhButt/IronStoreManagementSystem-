//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class SupplierPaymentMade
    {
        public int SupplierPaymentMadeId { get; set; }
        public int SupplierId { get; set; }
        public int PaymentMade { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public int StationSupplierPaymentMadeId { get; set; }
        public int StationSupplierId { get; set; }
        public int StatusCode { get; set; }
    
        public virtual Supplier Supplier { get; set; }
    }
}
