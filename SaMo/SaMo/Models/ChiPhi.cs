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
    
    public partial class ChiPhi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiPhi()
        {
            this.dKChiPhis = new HashSet<dKChiPhi>();
        }
    
        public int idChiPhi { get; set; }
        public string tenChiPhi { get; set; }
        public string moTa { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public Nullable<System.DateTime> ngayTao { get; set; }
        public Nullable<System.DateTime> ngayUpdate { get; set; }
        public string hinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dKChiPhi> dKChiPhis { get; set; }
    }
}