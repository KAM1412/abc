namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEN")]
    public partial class GIAOVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAOVIEN()
        {
            LOPHOCs = new HashSet<LOPHOC>();
        }

        [Key]
        public int MaGV { get; set; }

        [StringLength(30)]
        public string TenGV { get; set; }

        public int? MaMH { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [StringLength(100)]
        public string QueQuan { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOC> LOPHOCs { get; set; }
    }
}
