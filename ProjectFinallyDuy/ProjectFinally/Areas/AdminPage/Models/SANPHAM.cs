//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectFinally.Areas.AdminPage.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            this.CTDHs = new HashSet<CTDH>();
        }
    
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public string motaSP { get; set; }
        public string imageSP { get; set; }
        public string baohanhSP { get; set; }
        public Nullable<int> soluongSP { get; set; }
        public Nullable<int> dongiaSP { get; set; }
        public string hangsxSP { get; set; }
        public Nullable<bool> pheduyet { get; set; }
        public string maGH { get; set; }
        public string color1 { get; set; }
        public string color2 { get; set; }
        public string color3 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDHs { get; set; }
        public virtual GIANHANG GIANHANG { get; set; }
    }
}
