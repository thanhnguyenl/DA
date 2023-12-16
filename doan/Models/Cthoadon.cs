using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace doan.Models
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
        public int? DonGia { get; set; }
        public short? SoLuong { get; set; }
        public int? ThanhTien { get; set; }

        [ForeignKey(nameof(MaHd))]
        [InverseProperty(nameof(Hoadon.Cthoadon))]
        public virtual Hoadon MaHdNavigation { get; set; }
        [ForeignKey(nameof(MaMh))]
        [InverseProperty(nameof(Mathang.Cthoadon))]
        public virtual Mathang MaMhNavigation { get; set; }
    }
}
