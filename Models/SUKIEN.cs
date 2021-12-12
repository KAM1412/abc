namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUKIEN")]
    public partial class SUKIEN
    {
        public int? MaLH { get; set; }

        [Key]
        public int MaSK { get; set; }

        [StringLength(100)]
        public string TenSK { get; set; }

        [Column(TypeName = "date")]
        public DateTime? THOIGIAN { get; set; }

        [StringLength(500)]
        public string NOIDUNG { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        public virtual LOPHOC LOPHOC { get; set; }
    }
}
