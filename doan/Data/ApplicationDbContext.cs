using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using doan.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doan.Data
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

        public virtual DbSet<Cthoadon> Cthoadon { get; set; }
        public virtual DbSet<Cuahang> Cuahang { get; set; }
        public virtual DbSet<Danhmuc> Danhmuc { get; set; }
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
            modelBuilder.Entity<Cthoadon>(entity =>
            {
                entity.HasKey(e => e.MaCthd)
                    .HasName("PK__CTHOADON__1E4FA77166B96E60");

                entity.Property(e => e.DonGia).HasDefaultValueSql("((0))");

                entity.Property(e => e.SoLuong).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Cthoadon)
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaHD__4CA06362");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Cthoadon)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaMH__4D94879B");
            });

            modelBuilder.Entity<Cuahang>(entity =>
            {
                entity.HasKey(e => e.MaCh)
                    .HasName("PK__CUAHANG__27258E0067610612");

                entity.Property(e => e.DienThoai).IsUnicode(false);
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DANHMUC__2725866E2AA1E3F3");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HOADON__2725A6E08762BDA0");

                entity.Property(e => e.Ngay).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TongTien).HasDefaultValueSql("((0))");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MaKH__48CFD27E");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHACHHAN__2725CF1E3280D139");

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);
            });

            modelBuilder.Entity<Mathang>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MATHANG__2725DFD9C523D7C5");

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
                    .HasName("PK__NHANVIEN__2725D70A56BB8EFF");

                entity.Property(e => e.DienThoai).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.MatKhau).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
