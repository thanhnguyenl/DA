using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mvc.Models
{
    [Table("CUAHANG")]
    public partial class Cuahang
    {
        [Key]
        [Column("MaCH")]
        public int MaCh { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Tên cửa hàng")]
        public string Ten { get; set; }
        [StringLength(20)]
        [Display(Name = "Điện thoại")]
        public string DienThoai { get; set; }
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }
}
