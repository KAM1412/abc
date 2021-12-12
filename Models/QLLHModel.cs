using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebQuanLyLopHoc_Nhom8.Models
{
    public partial class QLLHModel : DbContext
    {
        public QLLHModel()
            : base("name=QLLHModel")
        {
        }

        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<HOCPHI> HOCPHIs { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHs { get; set; }
        public virtual DbSet<KETQUA> KETQUAs { get; set; }
        public virtual DbSet<KHOI> KHOIs { get; set; }
        public virtual DbSet<KITHI> KITHIs { get; set; }
        public virtual DbSet<LOPHOC> LOPHOCs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<SUKIEN> SUKIENs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<TTPHUHUYNHH> TTPHUHUYNHHS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.LOPHOCs)
                .WithOptional(e => e.GIAOVIEN)
                .HasForeignKey(e => e.MaGVCHUNHIEM);

            modelBuilder.Entity<HOCPHI>()
                .Property(e => e.MaHS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOCPHI>()
                .Property(e => e.HocPhi1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.MaHS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.GioiTinh)
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.MaHS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KITHI>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.KITHI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.KETQUAs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Matkhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TTPHUHUYNHH>()
                .Property(e => e.MaHS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TTPHUHUYNHH>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TTPHUHUYNHH>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
