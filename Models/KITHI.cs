namespace WebQuanLyLopHoc_Nhom8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KITHI")]
    public partial class KITHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KITHI()
        {
            KETQUAs = new HashSet<KETQUA>();
        }

        [Key]
        public int MaKiThi { get; set; }

        [StringLength(100)]
        public string TenKiThi { get; set; }

        public DateTime? ThoiGian { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUAs { get; set; }
    }
}
