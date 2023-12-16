using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doan.Models
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
        public DateTime? Ngay { get; set; }
        public int? TongTien { get; set; }
        [Column("MaKH")]
        public int MaKh { get; set; }
        public int? TrangThai { get; set; }

        [ForeignKey(nameof(MaKh))]
        [InverseProperty(nameof(Khachhang.Hoadon))]
        public virtual Khachhang MaKhNavigation { get; set; }
        [InverseProperty("MaHdNavigation")]
        public virtual ICollection<Cthoadon> Cthoadon { get; set; }
    }
}
