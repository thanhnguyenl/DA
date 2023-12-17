using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("DIACHI")]
    public partial class Diachi
    {
        [Key]
        [Column("MaDC")]
        public int MaDc { get; set; }
        [Column("MaKH")]
        public int MaKh { get; set; }
        [Required]
        [Column("DiaChi")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi1 { get; set; }
        [StringLength(20)]
        [Display(Name = "Phường/Xã")]
        public string PhuongXa { get; set; }
        [StringLength(50)]
        [Display(Name = "Quận/Huyện")]
        public string QuanHuyen { get; set; }
        [StringLength(50)]
        [Display(Name = "Tỉnh/Thành")]
        public string TinhThanh { get; set; }
        [Display(Name = "Mặc định")]
        public int? MacDinh { get; set; }
        [Display(Name = "Mã khách hàng")]
        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(Khachhang.Diachi))]
        public virtual Khachhang MaKhNavigation { get; set; }
    }
}
