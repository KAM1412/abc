namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCPHI")]
    public partial class HOCPHI
    {
        [Key]
        public int MaHocPHi { get; set; }

        [StringLength(5)]
        public string MaHS { get; set; }

        [Column("HocPhi", TypeName = "money")]
        public decimal? HocPhi1 { get; set; }

        public DateTime? NgayDong { get; set; }

        [StringLength(10)]
        public string TinhTrang { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }
    }
}
