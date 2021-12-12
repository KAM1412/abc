namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOI")]
    public partial class KHOI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOI()
        {
            LOPHOCs = new HashSet<LOPHOC>();
        }

        [Key]
        public int MaKhoi { get; set; }

        [StringLength(20)]
        public string TenKhoi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOC> LOPHOCs { get; set; }
    }
}
