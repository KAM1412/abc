namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUA")]
    public partial class KETQUA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaMH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaKiThi { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string MaHS { get; set; }

        public double? Diem { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual KITHI KITHI { get; set; }

        public virtual MONHOC MONHOC { get; set; }
    }
}
