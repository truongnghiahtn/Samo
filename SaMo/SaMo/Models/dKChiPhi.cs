//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaMo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class dKChiPhi
    {
        public int idDKChiPhi { get; set; }
        public int idKhachHang { get; set; }
        public int idChiPhi { get; set; }
        public decimal tien { get; set; }
        public string moTa { get; set; }
        public Nullable<System.DateTime> ngayTao { get; set; }
        public Nullable<System.DateTime> ngayUpdate { get; set; }
    
        public virtual ChiPhi ChiPhi { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
