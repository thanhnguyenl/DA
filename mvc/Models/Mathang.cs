using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("MATHANG")]
    public partial class Mathang
    {
        public Mathang()
        {
            Cthoadon = new HashSet<Cthoadon>();
        }

        [Key]
        [Column("MaMH")]
        public int MaMh { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        public string Ten { get; set; }
        [Display(Name = "Giá gốc")]
        public int? GiaGoc { get; set; }
        [Display(Name = "Giá bán")]
        public int GiaBan { get; set; }
        [Display(Name = "Số lượng")]
        public short? SoLuong { get; set; }
        [StringLength(1000)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [StringLength(255)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Column("MaDM")]
        public int MaDm { get; set; }
        public int? LuotXem { get; set; }
        public int? LuotMua { get; set; }
        [Display(Name = "Danh mục")]
        [ForeignKey(nameof(MaDm))]
        [InverseProperty(nameof(Danhmuc.Mathang))]
        public virtual Danhmuc MaDmNavigation { get; set; }
        [InverseProperty("MaMhNavigation")]
        public virtual ICollection<Cthoadon> Cthoadon { get; set; }
    }
}
