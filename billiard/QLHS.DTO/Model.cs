using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Bida.DTO
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model12")
        {
        }

        public virtual DbSet<BAN> BANs { get; set; }
        public virtual DbSet<BIENLAI> BIENLAIs { get; set; }
        public virtual DbSet<CHITIETBIENLAI> CHITIETBIENLAIs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NUOC> NUOCs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
        public virtual DbSet<QUANLI> QUANLIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAN>()
                .HasMany(e => e.BIENLAIs)
                .WithRequired(e => e.BAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BIENLAI>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<BIENLAI>()
                .Property(e => e.TONGTIEN)
                .IsFixedLength();

            modelBuilder.Entity<CHITIETBIENLAI>()
                .Property(e => e.MAKH)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETBIENLAI>()
                .Property(e => e.MABIENLAI)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETBIENLAI>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.PASSNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.BIENLAIs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasOptional(e => e.QUANLI)
                .WithRequired(e => e.NHANVIEN);

            modelBuilder.Entity<QUANLI>()
                .Property(e => e.MANHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLI>()
                .Property(e => e.TENNHANVIEN)
                .IsUnicode(false);

            modelBuilder.Entity<QUANLI>()
                .Property(e => e.PASSNV)
                .IsUnicode(false);
        }
    }
}
