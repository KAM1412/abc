namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        public int MaTK { get; set; }

        [StringLength(50)]
        public string TenTK { get; set; }

        [StringLength(16)]
        public string Matkhau { get; set; }

        [StringLength(10)]
        public string PHANQUYEN { get; set; }
    }
}
