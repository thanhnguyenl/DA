using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("HOADON")]
    public partial class Hoadon
    {
        public Hoadon()
        {
            Cthoadon = new HashSet<Cthoadon>();
        }

        [Key]
        [Column("MaHD")]
        public int MaHd { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Ngày")]
        public DateTime? Ngay { get; set; }
        [Display(Name = "Tổng tiền")]
        public int? TongTien { get; set; }
        [Column("MaKH")]
        [Display(Name = "Mã khách hàng")]
        public int MaKh { get; set; }
        [Display(Name = "Trạng thái")]
        public int? TrangThai { get; set; }
        [Display(Name = "Tên khách hàng")]
        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(Khachhang.Hoadon))]
        public virtual Khachhang MaKhNavigation { get; set; }
        [InverseProperty("MaHdNavigation")]
        public virtual ICollection<Cthoadon> Cthoadon { get; set; }
    }
}
