using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("CTHOADON")]
    public partial class Cthoadon
    {
        [Key]
        [Column("MaCTHD")]
        public int MaCthd { get; set; }
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Column("MaMH")]
        public int MaMh { get; set; }
        [Display(Name = "Đơn giá")]
        public int? DonGia { get; set; }
        [Display(Name = "Số lượng")]
        public short? SoLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public int? ThanhTien { get; set; }
        [Display(Name = "Mã hóa đơn")]
        [ForeignKey(nameof(MaHd))]
        [InverseProperty(nameof(Hoadon.Cthoadon))]
        public virtual Hoadon MaHdNavigation { get; set; }
        [ForeignKey(nameof(MaMh))]
        [InverseProperty(nameof(Mathang.Cthoadon))]
        [Display(Name = "Tên mặt hàng")]
        public virtual Mathang MaMhNavigation { get; set; }
    }
}
