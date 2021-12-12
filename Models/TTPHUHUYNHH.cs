namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TTPHUHUYNHHS")]
    public partial class TTPHUHUYNHH
    {
        [Key]
        public int MaPH { get; set; }

        [StringLength(5)]
        public string MaHS { get; set; }

        [StringLength(50)]
        public string TenPhuHuynh { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }
    }
}
