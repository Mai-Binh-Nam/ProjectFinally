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
    
    public partial class GIANHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIANHANG()
        {
            this.SANPHAMs = new HashSet<SANPHAM>();
        }
    
        public string maGH { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string diachiGH { get; set; }
        public Nullable<int> sdt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SANPHAM> SANPHAMs { get; set; }
    }
}
