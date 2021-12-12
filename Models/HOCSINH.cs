namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCSINH")]
    public partial class HOCSINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            HOCPHIs = new HashSet<HOCPHI>();
            KETQUAs = new HashSet<KETQUA>();
            TTPHUHUYNHHS = new HashSet<TTPHUHUYNHH>();
        }

        [Key]
        [StringLength(5)]
        public string MaHS { get; set; }

        [StringLength(50)]
        public string TenHS { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string QueQuan { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(30)]
        public string HinhAnh { get; set; }

        public int? MaLH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCPHI> HOCPHIs { get; set; }

        public virtual LOPHOC LOPHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TTPHUHUYNHH> TTPHUHUYNHHS { get; set; }
    }
}
