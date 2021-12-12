namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOPHOC")]
    public partial class LOPHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOPHOC()
        {
            HOCSINHs = new HashSet<HOCSINH>();
            SUKIENs = new HashSet<SUKIEN>();
        }

        [Key]
        public int MaLH { get; set; }

        [StringLength(50)]
        public string TenLH { get; set; }

        public int? MaKhoi { get; set; }

        public int? MaGVCHUNHIEM { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }

        public virtual KHOI KHOI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUKIEN> SUKIENs { get; set; }
    }
}
