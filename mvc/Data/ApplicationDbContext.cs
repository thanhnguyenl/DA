using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using mvc.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chucvu> Chucvu { get; set; }
        public virtual DbSet<Cthoadon> Cthoadon { get; set; }
        public virtual DbSet<Cuahang> Cuahang { get; set; }
        public virtual DbSet<Danhmuc> Danhmuc { get; set; }
        public virtual DbSet<Diachi> Diachi { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Mathang> Mathang { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MSI;Database=shop;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chucvu>(entity =>
            {
                entity.HasKey(e => e.MaCv)
                    .HasName("PK__CHUCVU__27258E76946A006E");

                entity.Property(e => e.HeSo).HasDefaultValueSql("((1.0))");
            });

            modelBuilder.Entity<Cthoadon>(entity =>
            {
                entity.HasKey(e => e.MaCthd)
                    .HasName("PK__CTHOADON__1E4FA771135AE52E");

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Cthoadon)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaHD__571DF1D5");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Cthoadon)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaMH__5812160E");
            });

            modelBuilder.Entity<Cuahang>(entity =>
            {
                entity.HasKey(e => e.MaCh)
                    .HasName("PK__CUAHANG__27258E005EACCE91");

                entity.Property(e => e.DienThoai).IsUnicode(false);
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DANHMUC__2725866EC4DAA1BE");
            });

            modelBuilder.Entity<Diachi>(entity =>
            {
                entity.HasKey(e => e.MaDc)
                    .HasName("PK__DIACHI__27258664B8195F34");

                entity.Property(e => e.MacDinh).HasDefaultValueSql("((1))");

                entity.Property(e => e.PhuongXa)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'Đông Xuyên')");

                entity.Property(e => e.QuanHuyen)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'TP. Long Xuyên')");

                entity.Property(e => e.TinhThanh)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'An Giang')");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Diachi)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DIACHI__MaKH__4AB81AF0");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HOADON__2725A6E00A9AA5A1");

                entity.Property(e => e.Ngay).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TongTien).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MaKH__534D60F1");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHACHHAN__2725CF1E7B33F6C0");

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);
            });

            modelBuilder.Entity<Mathang>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MATHANG__2725DFD93E9A9B0D");

                entity.Property(e => e.GiaBan).HasDefaultValueSql("((0))");

                entity.Property(e => e.GiaGoc).HasDefaultValueSql("((0))");

                entity.Property(e => e.HinhAnh).IsUnicode(false);

                entity.Property(e => e.LuotMua).HasDefaultValueSql("((0))");

                entity.Property(e => e.LuotXem).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.Mathang)
                    .HasForeignKey(d => d.MaDm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATHANG__MaDM__3E52440B");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("PK__NHANVIEN__2725D70ADDE53795");

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);

                entity.HasOne(d => d.MaCvNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.MaCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NHANVIEN__MaCV__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
