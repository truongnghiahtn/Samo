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
    
    public partial class ThuNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThuNhap()
        {
            this.dKThuNhaps = new HashSet<dKThuNhap>();
        }
    
        public int idThuNhap { get; set; }
        public string tenThuNhap { get; set; }
        public string moTa { get; set; }
        public Nullable<bool> trangThai { get; set; }
        public Nullable<System.DateTime> ngayTao { get; set; }
        public Nullable<System.DateTime> ngayUpdate { get; set; }
        public string hinh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dKThuNhap> dKThuNhaps { get; set; }
    }
}
